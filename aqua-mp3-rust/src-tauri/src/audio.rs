use rodio::{Decoder, OutputStream, Sink};
use std::fs::File;
use std::io::BufReader;
use std::sync::mpsc::{Receiver, Sender};
use std::thread;

pub enum AudioCommand {
    Play(String),
    Pause,
    Resume,
    Stop,
}

pub struct AudioPlayer {
    tx: Sender<AudioCommand>,
}

impl AudioPlayer {
    pub fn new() -> Self {
        let (tx, rx): (Sender<AudioCommand>, Receiver<AudioCommand>) = std::sync::mpsc::channel();

        thread::spawn(move || {
            // Keep the stream alive in this thread
            let (_stream, stream_handle) = OutputStream::try_default().unwrap();
            let mut sink = Sink::try_new(&stream_handle).unwrap();

            for command in rx {
                match command {
                    AudioCommand::Play(path) => {
                        // Create a new sink to ensure clean state and replace current song
                        // rodio::Sink::stop() clears the queue but we want to be sure
                        // we drop the old sink and make a new one to mimic "switch song"
                        // Note: Dropping the old sink stops playback.

                        // We replace 'sink'
                        sink = Sink::try_new(&stream_handle).unwrap();

                        if let Ok(file) = File::open(&path) {
                            let file = BufReader::new(file);
                            if let Ok(source) = Decoder::new(file) {
                                sink.append(source);
                                sink.play();
                            } else {
                                println!("Failed to decode audio: {}", path);
                            }
                        } else {
                            println!("Failed to open file: {}", path);
                        }
                    }
                    AudioCommand::Pause => {
                        sink.pause();
                    }
                    AudioCommand::Resume => {
                        sink.play();
                    }
                    AudioCommand::Stop => {
                        sink.stop();
                        // Re-create sink to be ready
                        sink = Sink::try_new(&stream_handle).unwrap();
                    }
                }
            }
        });

        Self { tx }
    }

    pub fn play(&self, path: String) {
        let _ = self.tx.send(AudioCommand::Play(path));
    }

    pub fn pause(&self) {
        let _ = self.tx.send(AudioCommand::Pause);
    }

    pub fn resume(&self) {
        let _ = self.tx.send(AudioCommand::Resume);
    }

    pub fn stop(&self) {
        let _ = self.tx.send(AudioCommand::Stop);
    }
}

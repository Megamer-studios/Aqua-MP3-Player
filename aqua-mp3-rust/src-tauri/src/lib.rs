mod audio;
use audio::AudioPlayer;
use tauri::{AppHandle, State};
use tauri_plugin_dialog::DialogExt;

struct AppState {
    player: AudioPlayer,
}

#[tauri::command]
fn greet(name: &str) -> String {
    format!("Hello, {}! You've been greeted from Rust!", name)
}

#[tauri::command]
fn pick_music_folder(app: AppHandle) -> String {
    let result = app.dialog().file().blocking_pick_folder();
    match result {
        Some(path) => path.to_string(),
        None => "".to_string(),
    }
}

#[tauri::command]
fn get_songs(directory: String) -> Vec<String> {
    let mut songs = Vec::new();
    if directory.is_empty() {
        return songs;
    }

    if let Ok(entries) = std::fs::read_dir(&directory) {
        for entry in entries {
            if let Ok(entry) = entry {
                let path = entry.path();
                if path.is_file() {
                    if let Some(ext) = path.extension() {
                        let ext_str = ext.to_string_lossy().to_lowercase();
                        if ["mp3", "wav", "flac", "m4a", "ogg"].contains(&ext_str.as_str()) {
                            songs.push(path.to_string_lossy().to_string());
                        }
                    }
                }
            }
        }
    }
    // Sort songs alphabetically
    songs.sort();
    songs
}

#[tauri::command]
fn play_audio(state: State<AppState>, path: String) {
    state.player.play(path);
}

#[tauri::command]
fn pause_audio(state: State<AppState>) {
    state.player.pause();
}

#[tauri::command]
fn resume_audio(state: State<AppState>) {
    state.player.resume();
}

#[tauri::command]
fn stop_audio(state: State<AppState>) {
    state.player.stop();
}

#[cfg_attr(mobile, tauri::mobile_entry_point)]
pub fn run() {
    let player = AudioPlayer::new();

    tauri::Builder::default()
        .plugin(tauri_plugin_dialog::init())
        .plugin(tauri_plugin_opener::init())
        .manage(AppState { player })
        .invoke_handler(tauri::generate_handler![
            greet,
            pick_music_folder,
            get_songs,
            play_audio,
            pause_audio,
            resume_audio,
            stop_audio
        ])
        .run(tauri::generate_context!())
        .expect("error while running tauri application");
}

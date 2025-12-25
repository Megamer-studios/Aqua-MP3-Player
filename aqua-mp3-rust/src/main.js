const { invoke } = window.__TAURI__.core;
const { getCurrentWindow } = window.__TAURI__.window;

let playlist = [];
let currentSongIndex = 0;
let isPlaying = false;
let isRepeat = false;

const displayTitle = document.getElementById("song-name");
const displayIndex = document.getElementById("song-index");
const displayRpt = document.getElementById("rpt-status");

// Disable Context Menu
document.addEventListener('contextmenu', event => event.preventDefault());

// Controls
document.getElementById("btn-close").addEventListener("click", () => {
  // Force close logic
  getCurrentWindow().close();
});

document.getElementById("btn-menu").addEventListener("click", async () => {
  const selected = await invoke("pick_music_folder");
  if (selected) {
    loadSongs(selected);
  }
});

document.getElementById("btn-play").addEventListener("click", () => {
  if (playlist.length === 0) return;
  togglePause();
});

document.getElementById("btn-reset").addEventListener("click", async () => {
  if (playlist.length === 0) return;

  // Simplest "Reset" is Stop -> Play
  await invoke("stop_audio");
  if (isPlaying) {
    await playSong(currentSongIndex);
  } else {
    await playSong(currentSongIndex);
  }
});

document.getElementById("btn-next").addEventListener("click", next);
document.getElementById("btn-back").addEventListener("click", prev); // Back is Prev

document.getElementById("btn-repeat").addEventListener("click", () => {
  isRepeat = !isRepeat;
  displayRpt.textContent = isRepeat ? "RPT ON" : "RPT OFF";
});


// Logic
async function loadSongs(folder) {
  try {
    const songs = await invoke("get_songs", { directory: folder });
    playlist = songs;
    currentSongIndex = 0;

    if (playlist.length > 0) {
      updateDisplay();
    } else {
      displayTitle.textContent = "No MP3s found";
      displayIndex.textContent = "0";
    }
  } catch (e) {
    console.error(e);
    displayTitle.textContent = "Error";
  }
}

function updateDisplay() {
  if (playlist.length === 0) return;
  const path = playlist[currentSongIndex];
  const name = path.split(/[\\/]/).pop();
  displayTitle.textContent = name;
  displayIndex.textContent = currentSongIndex.toString();
}

async function playSong(index) {
  if (index < 0 || index >= playlist.length) return;
  currentSongIndex = index;
  updateDisplay();

  const path = playlist[index];
  try {
    await invoke("play_audio", { path });
    isPlaying = true;
  } catch (e) {
    console.error(e);
  }
}

async function togglePause() {
  if (isPlaying) {
    await invoke("pause_audio");
    isPlaying = false;
  } else {
    if (playlist.length > 0) {
      await invoke("resume_audio");
      isPlaying = true;
    }
  }
}

async function next() {
  let nextIndex = currentSongIndex + 1;
  if (nextIndex >= playlist.length) nextIndex = 0;
  playSong(nextIndex);
}

async function prev() {
  let prevIndex = currentSongIndex - 1;
  if (prevIndex < 0) prevIndex = playlist.length - 1;
  playSong(prevIndex);
}

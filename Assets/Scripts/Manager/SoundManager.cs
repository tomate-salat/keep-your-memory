using System;
using Common;
using State;
using UnityEngine;
using UnityEngine.Audio;

namespace Manager {
    public class SoundManager : MonoBehaviour {
        [Header("Game Settings")]
        [SerializeField] private GameSettings gameSettings;
        
        [Header("Volumes")]
        [SerializeField] private string master;
        [SerializeField] private string music;
        [SerializeField] private string effects;

        [Header("Sources")]
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private AudioSource musicSource;

        [Header("Clips")]
        [SerializeField] private AudioClip menuClip;
        [SerializeField] private AudioClip gameClip;
        [SerializeField] private AudioClip firstClockRoundClip;

        public void PlayMenuClip() => SwitchClip(menuClip);
        public void PlayGameClip() => SwitchClip(gameClip);

        public void PlayFirstClockRoundShot() => musicSource.PlayOneShot(firstClockRoundClip);

        public float MasterVolume {
            get => GetVolume(master);
            set => SetVolume(master, value);
        }

        public float MusicVolume {
            get => GetVolume(music);
            set => SetVolume(music, value);
        }

        public float EffectsVolume {
            get => GetVolume(effects);
            set => SetVolume(effects, value);
        }
        
        private readonly AutoListener autoListener = new AutoListener();

        private void Awake() {
            autoListener.Listen(gameSettings.OnMasterVolChanged, vol => MasterVolume = vol);
            autoListener.Listen(gameSettings.OnMusicVolChanged, vol => MusicVolume = vol);
            autoListener.Listen(gameSettings.OnEffectsVolChanged, vol => EffectsVolume = vol);
        }

        private void Start() {
            audioMixer.SetFloat(master, gameSettings.MasterVolume);
            audioMixer.SetFloat(music, gameSettings.MusicVolume);
            audioMixer.SetFloat(effects, gameSettings.EffectsVolume);
        }

        private void OnDestroy() {
            autoListener.RemoveListeners();
        }

        private void SwitchClip(AudioClip clip) {
            musicSource.Stop();
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }

        private void SetVolume(string key, float volume) {
            audioMixer.SetFloat(key, volume);
        }

        private float GetVolume(string key) {
            audioMixer.GetFloat(key, out var volume);

            return volume;
        }

    }
    
}
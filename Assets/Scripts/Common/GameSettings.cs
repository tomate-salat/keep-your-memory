using System.Runtime.CompilerServices;
using Events;
using UnityEngine;

namespace Common {
    
    [CreateAssetMenu]
    public class GameSettings : ScriptableObject {
        [Header("Game Play")]
        [SerializeField] private bool topIsForward = true;
        
        [Header("Volumes")]
        [SerializeField] private float masterVolume;
        [SerializeField] private float musicVolume;
        [SerializeField] private float effectsVolume;
        
        [Header("Events")]
        [SerializeField] private FloatEvent onMasterVolChanged;
        [SerializeField] private FloatEvent onMusicVolChanged;
        [SerializeField] private FloatEvent onEffectsVolChanged;

        public FloatEvent OnMasterVolChanged => onMasterVolChanged;
        public FloatEvent OnMusicVolChanged => onMusicVolChanged;
        public FloatEvent OnEffectsVolChanged => onEffectsVolChanged;
        
        public bool TopIsForward {
            get => GetInt(topIsForward ? 1 : 0) == 1;
            set => SetInt(value ? 0 : 1);
        }

        public float MasterVolume {
            get => GetFloat(masterVolume);
            set {
                SetFloat(value);
                
                OnMasterVolChanged.Invoke(value);
            }
        }

        public float MusicVolume {
            get => GetFloat(musicVolume);
            set {
                SetFloat(value);

                OnMusicVolChanged.Invoke(value);
            }
        }

        public float EffectsVolume {
            get => GetFloat(effectsVolume);
            set {
                SetFloat(value);
                
                OnEffectsVolChanged.Invoke(value);
            }
        }

        private static int GetInt(int defaultValue = default, [CallerMemberName] string prop = "") => PlayerPrefs.GetInt(Key(prop), defaultValue); 
        private static void SetInt(int value, [CallerMemberName] string prop = "") {
            PlayerPrefs.SetInt(Key(prop), value);
            PlayerPrefs.Save();
        }

        private static float GetFloat(float defaultValue = default, [CallerMemberName]string prop = "") => PlayerPrefs.GetFloat(Key(prop), defaultValue); 
        private static void SetFloat(float value = default, [CallerMemberName]string prop = "") {
            PlayerPrefs.SetFloat(Key(prop), value);
            PlayerPrefs.Save();
        }

        private static string Key(string prop) => $"settings.{prop}";
    }
    
}
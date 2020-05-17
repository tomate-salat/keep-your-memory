using System.Collections;
using Common;
using State;
using TMPro;
using Ui;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Manager {
    
    [RequireComponent(typeof(Canvas))]
    [RequireComponent(typeof(CanvasGroup))]
    public class MenuManager : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private float fadeSpeed = 1f;
        [SerializeField] private TabView tabView;
        [SerializeField] private StatsPanel statsPanel;
        
        [Header("Settings")]
        [SerializeField] private TMP_Dropdown movement;
        [SerializeField] private Slider master;
        [SerializeField] private Slider music;
        [SerializeField] private Slider effects;
        
        [Header("Events")]
        [SerializeField] private UnityEvent onStartGame;

        public UnityEvent OnStartGame => onStartGame;

        private Canvas canvas;
        private CanvasGroup canvasGroup;
        
        private readonly AutoListener autoListener = new AutoListener();
        
        private void Awake() {
            canvas = GetComponent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();

            movement.value = gameSettings.TopIsForward ? 0 : 1;
            
            master.value = gameSettings.MasterVolume;
            music.value = gameSettings.MusicVolume;
            effects.value = gameSettings.EffectsVolume;
            
            autoListener.Listen(movement.onValueChanged, option => gameSettings.TopIsForward = option == 1);
            autoListener.Listen(master.onValueChanged, vol => gameSettings.MasterVolume = vol);
            autoListener.Listen(music.onValueChanged, vol => gameSettings.MusicVolume = vol);
            autoListener.Listen(effects.onValueChanged, vol => gameSettings.EffectsVolume = vol);
        }

        private void OnDestroy() {
            autoListener.RemoveListeners();
        }

        public void StartGame() {
            StopAllCoroutines();
            
            OnStartGame.Invoke();

            StartCoroutine(HideMenu());
        }

        public void Show(int tab = 0) {
            statsPanel.Reload();
            
            StopAllCoroutines();

            tabView.Select(tab);
            
            StartCoroutine(ShowMenu());
        }

        private IEnumerator ShowMenu() {
            canvas.enabled = true;
            
            while (canvasGroup.alpha < 0.95f) {
                canvasGroup.alpha += Time.deltaTime * fadeSpeed;
                yield return null;
            }

            canvasGroup.alpha = 1f;
        } 

        private IEnumerator HideMenu() {
            while (canvasGroup.alpha > 0.2f) {
                canvasGroup.alpha -= Time.deltaTime * fadeSpeed;
                yield return null;
            }

            canvasGroup.alpha = 0;
            canvas.enabled = false;
        }

    }
    
}
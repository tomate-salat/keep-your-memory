using Common;
using State;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui {
    
    public class GameUi : MonoBehaviour {
        [Header("Stats")]
        [SerializeField] private GameStatistics statistics;

        [Header("Components")]
        [SerializeField] private GameObject pauseDialog;
        [SerializeField] private TextMeshProUGUI level;
        [SerializeField] private TextMeshProUGUI points;
        [SerializeField] private TextMeshProUGUI bombsKilled;
        [SerializeField] private Button continueGame;
        [SerializeField] private Button giveUpButton;

        [Header("Events")] 
        [SerializeField] private UnityEvent onPause;
        [SerializeField] private UnityEvent onContinue;
        [SerializeField] private UnityEvent onGiveUp;

        private string levelMask;
        private string pointsMask;
        private string bombsKilledMask;

        private bool paused;

        public bool Paused => paused;
        
        public UnityEvent OnGiveUp => onGiveUp;
        public UnityEvent OnPause => onPause;
        public UnityEvent OnContinue => onContinue;
        
        private readonly AutoListener autoListener = new AutoListener();
        
        private void Awake() {
            levelMask = level.text;
            pointsMask = points.text;
            bombsKilledMask = bombsKilled.text;
            
            autoListener.Listen(continueGame.onClick, ContinueGame);
            autoListener.Listen(giveUpButton.onClick, () => {
                ContinueGame();
                OnGiveUp.Invoke();
            });
        }

        private void Update() {
            level.SetText(levelMask, statistics.Level);
            points.SetText(pointsMask, statistics.Points);
            bombsKilled.SetText(bombsKilledMask, statistics.BombsKilled, statistics.BombsSpawned);

            if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P)) {
                if(Paused) ContinueGame();
                else PauseGame();
            }
        }

        private void PauseGame() {
            paused = true;
            Time.timeScale = 0;
            pauseDialog.SetActive(true);
            
            onPause.Invoke();
        }

        private void ContinueGame() {
            Time.timeScale = 1;
            pauseDialog.SetActive(false);

            paused = false;
            onContinue.Invoke();
        }
    }
    
}
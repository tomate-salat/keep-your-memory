using System.Collections;
using Common;
using Level;
using Player;
using UnityEngine;
using UnityEngine.Events;

namespace Manager {
    
    public class GameManager : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private GameStatistics statistics;
        [SerializeField] private Clock clock;
        [SerializeField] private PlayerSpawn playerSpawn;
        [SerializeField] private float minDelayBetweenWave = 5f;
        
        [Header("Cursor")]
        [SerializeField] private Texture2D crosshair;

        [Header("Events")]
        [SerializeField] private UnityEvent onGameStarted;
        [SerializeField] private UnityEvent onGameOver;

        public UnityEvent OnGameStarted => onGameStarted;
        public UnityEvent OnGameOver => onGameOver;
        
        public bool CanSpawnWave => Time.time > lastWaveSpawned + minDelayBetweenWave;
        
        private float lastWaveSpawned;
        
        public bool SpawnWave(bool force = false) {
            if (force || CanSpawnWave) {
                clock.MoveToStart();
                lastWaveSpawned = Time.time;
                statistics.Level++;
                
                return true;
            }

            return false;
        }

        public void UseGameCursor() {
            var hotspot = new Vector2(crosshair.width, crosshair.height) / 2;
            Cursor.SetCursor(crosshair, hotspot, CursorMode.ForceSoftware);        
        }

        public static void UseDefaultCursor() {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        
        public void StartGame() {
            statistics.InitNewGame();
            
            UseGameCursor();
            StartCoroutine(InitiateStart());
        }

        public void GameOver() {
            statistics.ApplyStats();
            
            UseDefaultCursor();
            OnGameOver.Invoke();
        }

        private IEnumerator InitiateStart() {
            clock.MoveToStart();

            while (!clock.OrdinaryMode) {
                yield return null;
            }
            
            var player = playerSpawn.Spawn();
            player.WeaponSystemActive = false;
            
            yield return new WaitForFixedUpdate();

            SpawnWave(true);

            player.WeaponSystemActive = true;
            onGameStarted.Invoke();
        }

    }
    
}
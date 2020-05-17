using System.Runtime.CompilerServices;
using UnityEngine;

namespace Common {
    
    [CreateAssetMenu]
    public class GameStatistics : ScriptableObject {
        [SerializeField] private int level;
        [SerializeField] private int bombsKilled;
        [SerializeField] private int bombsSpawned;
        [SerializeField] private int points;

        public int Level {
            get => level;
            set => level = value;
        }

        public int BombsKilled {
            get => bombsKilled;
            set => bombsKilled = value;
        }

        public int BombsSpawned {
            get => bombsSpawned;
            set => bombsSpawned = value;
        }

        public int Points {
            get => points;
            set => points = value;
        }

        public static int GamesPlayed {
            get => GetValue();
            private set => SetValue(value);
        }

        public static int MaxLevel {
            get => GetValue();
            private set => SetValue(value);
        }

        public static int MaxPoints {
            get => GetValue();
            private set => SetValue(value);
        }

        public static int SumBombsKilled {
            get => GetValue();
            private set => SetValue(value);
        }

        public static int MaxBombsKilled {
            get => GetValue();
            private set => SetValue(value);
        }
        
        private void OnEnable() => InitNewGame();

        public void InitNewGame() {
            level = bombsKilled = bombsSpawned = points = 0;
        }

        public void ApplyStats() {
            GamesPlayed++;
            SumBombsKilled += bombsKilled;
            
            MaxLevel = Mathf.Max(MaxLevel, level);
            MaxPoints = Mathf.Max(MaxPoints, points);
            MaxBombsKilled = Mathf.Max(MaxBombsKilled, bombsKilled);
            
            PlayerPrefs.Save();
        }

        private static int GetValue([CallerMemberName] string caller = "unknown") {
            return PlayerPrefs.GetInt(Key(caller), 0);
        }

        private static void SetValue(int value, [CallerMemberName] string caller = "unknown") {
            PlayerPrefs.SetInt(Key(caller), value);
        }

        private static string Key(string name) => $"stats.{name}";

    }
}
using Common;
using UnityEngine;

namespace Ui {

    public class StatsPanel : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private GameStatistics statistics;

        [Header("Last Run")]
        [SerializeField] private TmpMask lastRunLevel;
        [SerializeField] private TmpMask lastRunPoints;
        [SerializeField] private TmpMask lastRunBombsKilled;
        [SerializeField] private TmpMask lastRunBombsSpawned;

        [Header("Overall")]
        [SerializeField] private TmpMask gamesPlayed;
        [SerializeField] private TmpMask highestLevel;
        [SerializeField] private TmpMask highestPoints;
        [SerializeField] private TmpMask sumBombsKilled;
        [SerializeField] private TmpMask highestBombKills;

        private void OnEnable() {
            Reload();
        }

        public void Reload() {
            lastRunLevel.Value = statistics.Level;
            lastRunPoints.Value = statistics.Points;
            lastRunBombsKilled.Value = statistics.BombsKilled;
            lastRunBombsSpawned.Value = statistics.BombsSpawned;

            gamesPlayed.Value = GameStatistics.GamesPlayed;
            highestLevel.Value = GameStatistics.MaxLevel;
            highestPoints.Value = GameStatistics.MaxPoints;
            sumBombsKilled.Value = GameStatistics.SumBombsKilled;
            highestBombKills.Value = GameStatistics.MaxBombsKilled;
        }
    }
    
}
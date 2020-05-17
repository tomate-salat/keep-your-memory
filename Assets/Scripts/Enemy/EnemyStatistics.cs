using Common;
using State;
using UnityEngine;

namespace Enemy {
    public class EnemyStatistics : MonoBehaviour {
        [SerializeField] private GameStatistics statistics;
        [SerializeField] private Health enemyHealth;

        private readonly AutoListener autoListener = new AutoListener();

        private void Awake() {
            autoListener.Listen(enemyHealth.OnDamageTaken, dmg => statistics.Points += dmg);
            autoListener.Listen(enemyHealth.OnDead, () => statistics.BombsKilled ++);
        }

        private void OnEnable() {
            statistics.BombsSpawned++;
        }

        private void OnDestroy() {
            autoListener.RemoveListeners();
        }
    }
}
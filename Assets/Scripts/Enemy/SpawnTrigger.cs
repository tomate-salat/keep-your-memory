using UnityEngine;

namespace Enemy {
    public class SpawnTrigger : MonoBehaviour {

        private EnemySpawner enemySpawner;

        private void Awake() {
            enemySpawner = GetComponentInParent<EnemySpawner>();
        }

        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Clock Arm")) {
                enemySpawner.SpawnEnemy(transform);
            }
        }
    }
}
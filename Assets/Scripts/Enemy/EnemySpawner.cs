using System.Collections;
using Common;
using Player;
using UnityEngine;

namespace Enemy {
    public class EnemySpawner : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private GameObject enemy;
        [SerializeField] private Transform activeBombs;
        [SerializeField] private Transform cachedBombs;
        [SerializeField] private int healthBonusModifier = 2;

        public int EnemyLevel { get; set; }
        
        private GameObject player;

        private void Awake() {
            cachedBombs.gameObject.SetActive(false);
        }

        public void SetPlayer(PlayerCharacter player) {
            this.player = player.gameObject;
        }

        public void SpawnEnemy(Transform position) {
            if (player == null) return;
            
            var instance = cachedBombs.childCount == 0 ? CreateNew(position) : ReUse(position);

            StartCoroutine(InitiateEnemy(instance));
        }

        public void CleanUp() {
            StopAllCoroutines();
            
            player = null;
            
            foreach (Transform bomb in activeBombs) {
                bomb.GetComponent<EnemyDetonation>().Detonate(false);
            }
        }

        private IEnumerator InitiateEnemy(GameObject enemy) {
            var chaseTarget = enemy.GetComponent<ChaseTarget>();
            var ghostify = enemy.GetComponent<Ghostify>();

            enemy.GetComponent<Health>().HealthValue += EnemyLevel * healthBonusModifier;
            
            chaseTarget.Target = null;
            ghostify.Appear();

            while (ghostify.TransitionValue > 0.1f) yield return null;

            chaseTarget.Target = player.transform;
        }

        private GameObject CreateNew(Transform position) {
            
            var instance = Instantiate(enemy, position.position, position.rotation, activeBombs);
            var enemyDetonation = instance.GetComponent<EnemyDetonation>();
            enemyDetonation.OnExploded.AddListener(CacheBomb);

            return instance;
        }

        private GameObject ReUse(Transform position) {
            var instance = cachedBombs.GetChild(0);
            instance.parent = activeBombs;
            instance.position = position.position;
            instance.rotation = position.rotation;
            
            instance.GetComponent<CacheAble>().Restore();
            
            return instance.gameObject;
        }

        private void CacheBomb(GameObject bomb) {
            bomb.transform.parent = cachedBombs;
        }
    }
}
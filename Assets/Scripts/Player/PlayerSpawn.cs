using Events;
using UnityEngine;

namespace Player {
    
    public class PlayerSpawn : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private PlayerCharacter playerPrefab;

        [Header("Events")]
        [SerializeField] private PlayerCharacterEvent onPlayerSpawned ;

        public PlayerCharacterEvent OnPlayerSpawned => onPlayerSpawned;
        
        public PlayerCharacter Spawn() {
            var player = Instantiate(playerPrefab, transform);
            
            OnPlayerSpawned.Invoke(player);
            
            return player;
        }

        public void KillPlayer() {
            foreach(Transform player in transform) {
                player.GetComponent<PlayerDetonation>().Detonate();
            }
        }
        
    }
    
}
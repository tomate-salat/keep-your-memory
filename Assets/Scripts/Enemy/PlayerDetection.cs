using Events;
using UnityEngine;

namespace Enemy {
    public class PlayerDetection : MonoBehaviour {
        [SerializeField] private GameObjectEvent onPlayerInRange;

        public GameObjectEvent OnPlayerInRange => onPlayerInRange;
        
        private void OnTriggerEnter(Collider other) {
            var otherBody = other.attachedRigidbody;

            if (otherBody != null && otherBody.CompareTag("Player")) {
                OnPlayerInRange.Invoke(otherBody.gameObject);
            }
        }
        
    }
}
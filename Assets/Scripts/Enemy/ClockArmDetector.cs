using UnityEngine;

namespace Enemy {
    public class ClockArmDetector : MonoBehaviour {
        [SerializeField] private Ghostify ghostify;
        
        private void OnTriggerEnter(Collider other) {
            if (other.CompareTag("Clock Arm")) {
                ghostify.GhostMode = true;
            }
        }

        private void OnTriggerExit(Collider other) {
            if (other.CompareTag("Clock Arm")) {
                ghostify.GhostMode = false;
            }
        }
    }
}
using UnityEngine;

namespace Player {
    
    [RequireComponent(typeof(Rigidbody))]
    public class BulletDirector : MonoBehaviour {
        [SerializeField] private Vector3 velocityOnStart;

        private Rigidbody body;

        private void Awake() {
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            body.velocity = velocityOnStart;
        }
    }
}
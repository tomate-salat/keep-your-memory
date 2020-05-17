using Common;
using UnityEngine;

namespace Player {
    
    [RequireComponent(typeof(Rigidbody))]
    public class MoveController : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private GameSettings gameSettings;
        [SerializeField] private float speed = 10;
        [SerializeField] private float speedWhileCharging = 2;

        private Rigidbody body;

        private float Speed => Input.GetButton("Fire1") ? speedWhileCharging : speed;
        private Vector3 Forward => !gameSettings.TopIsForward ? transform.forward : Vector3.forward;
        private Vector3 Right => !gameSettings.TopIsForward ? transform.right : Vector3.right;
        
        private void Awake() {
            body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");

            var move = Vector3.zero;

            if (Mathf.Abs(vertical) > 0.1f) {
                move += Forward * vertical * Speed * Time.fixedDeltaTime;
            }
            
            if (Mathf.Abs(horizontal) > 0.1f) {
                move += Right * horizontal * Speed * Time.fixedDeltaTime;
            }

            if (move != Vector3.zero) {
                body.MovePosition(body.position + move);
            }

        }
        
    }
    
}
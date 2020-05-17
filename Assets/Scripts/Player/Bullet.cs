using Enemy;
using UnityEngine;

namespace Player {
    
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour {
        [SerializeField] private float speed;
        [SerializeField] private int damage;
        [SerializeField] private float chargeBonus;
        
        private Rigidbody body;

        public int Damage => (int) Mathf.Max(1, damage * chargeBonus);
        
        public float ChargeBonus {
            get => chargeBonus;
            set => chargeBonus = value;
        }

        private void Awake() {
            body = GetComponent<Rigidbody>();
        }

        private void Start() {
            body.velocity = transform.forward * speed * chargeBonus;
        }

        private void OnCollisionEnter(Collision other) {
            var target = other.rigidbody;

            if (target != null && target.CompareTag("Enemy")) {
                target.GetComponent<Health>().TakeDamage(Damage);
            }
            
            damage /= 2;
        }
    }
    
}
using Common;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy {
    
    public class Health : MonoBehaviour, ICacheAble {
        [Header("Config")]
        [SerializeField] private int health = 30;
        [SerializeField] private IntEvent onDamageTaken;

        [Header("Damaged")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip damagedClip;
        
        [Header("Events")]
        [SerializeField] private UnityEvent onDead;

        public UnityEvent OnDead => onDead;
        
        public int HealthValue {
            get => health;
            set => health = value;
        }
        
        public IntEvent OnDamageTaken => onDamageTaken;

        private int initialHealth;

        private void Awake() {
            initialHealth = health;
        }

        public void TakeDamage(int damage) {
            health -= damage;

            OnDamageTaken.Invoke(damage);
            
            if (health <= 0) {
                OnDead.Invoke();
            } else {
                audioSource.PlayOneShot(damagedClip, 0.8f);
            }
        }

        public void RestoreFromCache() {
            health = initialHealth;
        }
    }
    
}
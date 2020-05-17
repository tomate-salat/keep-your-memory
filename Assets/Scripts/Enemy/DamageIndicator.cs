using Ui;
using UnityEngine;

namespace Enemy {
    
    [RequireComponent(typeof(Health))]
    public class DamageIndicator : MonoBehaviour {
        [SerializeField] private FloatingValue floatingValuePrefab;
        [SerializeField] private Gradient gradient;
        [SerializeField] private Vector3 offset = Vector3.up;

        private Health health;

        private void Awake() {
            health = GetComponent<Health>();
        }

        public void OnDamage(int damage) {
            if (damage < 1) return;
            
            
            var uiText = Instantiate(floatingValuePrefab, transform.position + offset, Quaternion.identity);
            uiText.TextColor = GetColor(damage);
            uiText.Value = -damage;
        }

        private Color GetColor(int damage) {
            var time = 1f;

            if (health.HealthValue > 0) {
                time = (float) damage / health.HealthValue;
            }
            
            return gradient.Evaluate(time);
        }
        
    }

}
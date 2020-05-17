using System.Linq;
using Common;
using Events;
using UnityEngine;

namespace Enemy {
    
    [RequireComponent(typeof(Rigidbody))]
    public class EnemyDetonation : Detonation {
        [Header("Explosion Settings")]
        [SerializeField] private float explosionRadius;
        [SerializeField] private Vector3 explosionCenter;

        [Header("Events")]
        [SerializeField] private GameObjectEvent onExploded;

        public GameObjectEvent OnExploded => onExploded;

        public Vector3 ExplosionCenter => transform.position + explosionCenter;
        
        protected override void ExplosionTriggered() {
            Physics.OverlapSphere(ExplosionCenter, explosionRadius)
                .Select(col => col.attachedRigidbody != null ? col.attachedRigidbody.GetComponent<IReactOnDetonation>() : null)
                .Where(reaction => reaction != null)
                .ToList()
                .ForEach(reaction => reaction.OnReact());
        }

        protected override void ExplosionDone() {
            OnExploded.Invoke(gameObject);
        }
        
        private void OnDrawGizmosSelected() {
            Gizmos.color = Color.red;
            
            Gizmos.DrawSphere(ExplosionCenter, 0.1f);
            Gizmos.DrawWireSphere(ExplosionCenter, explosionRadius);
        }
    }
}
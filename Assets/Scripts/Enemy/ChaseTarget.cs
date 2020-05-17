using Common;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy {
    
    public class ChaseTarget : MonoBehaviour, ICacheAble {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform target;

        public Transform Target {
            get => target;
            set => target = value;
        }

        public void StartChasing() {
            agent.enabled = true;
            agent.isStopped = false;
            enabled = true;
        }
        
        public void StopChasing() {
            agent.isStopped = true;
            agent.enabled = false;
            enabled = false;
        }
        
        private void Update() {
            if (target != null) {
                agent.destination = target.position;
            }
        }

        public void RestoreFromCache() {
            StartChasing();
        }
    }
    
}
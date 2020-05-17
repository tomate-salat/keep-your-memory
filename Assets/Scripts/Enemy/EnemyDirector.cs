using UnityEngine;

namespace Enemy {
    
    [ExecuteAlways]
    [RequireComponent(typeof(Ghostify))]
    public class EnemyDirector : MonoBehaviour {
        [SerializeField] private bool asGhost;
        
        private Ghostify ghostify;

        private bool isGhost;
        
        private void Awake() {
            ghostify = GetComponent<Ghostify>();
        }

        private void Update() {
            if (asGhost != isGhost) {
                ghostify.GhostMode = asGhost;
                isGhost = asGhost;
            }
        }
    }
}
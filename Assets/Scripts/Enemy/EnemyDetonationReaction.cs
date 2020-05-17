using Common;
using UnityEngine;

namespace Enemy {
    
    [RequireComponent(typeof(Ghostify))]
    public class EnemyDetonationReaction : MonoBehaviour, IReactOnDetonation {

        private Ghostify ghostify;

        private void Awake() {
            ghostify = GetComponent<Ghostify>();
        }


        public void OnReact() {
            ghostify.Appear();
        }
    }
    
}
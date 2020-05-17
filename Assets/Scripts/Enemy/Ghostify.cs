using System.Collections;
using UnityEngine;

namespace Enemy {
    public class Ghostify : MonoBehaviour {
        private static readonly int Transition = Shader.PropertyToID("_Transition");

        [SerializeField] private float transitionSpeed = 1f;
        [SerializeField] private SkinnedMeshRenderer mesh;

        private Material material;

        public bool GhostMode {
            set {
                StopAllCoroutines();
                StartCoroutine(value ? AsGhost() : AsNormal());
            }
        }

        public float TransitionValue {
            get => material.GetFloat(Transition);
            private set => material.SetFloat(Transition, value);
        }
        
        private void Awake() {
            material = mesh.material;
        }

        public void Appear() {
            TransitionValue = 1f;
            GhostMode = false;
        }

        private IEnumerator AsNormal() {
            while (TransitionValue > 0f) {
                TransitionValue -= Time.deltaTime * transitionSpeed;
                yield return null;
            }

            TransitionValue = 0f;
        }

        private IEnumerator AsGhost() {
            while (TransitionValue < 1f) {
                TransitionValue += Time.deltaTime * transitionSpeed;
                yield return null;
            }

            TransitionValue = 1f;
        }

    }
}
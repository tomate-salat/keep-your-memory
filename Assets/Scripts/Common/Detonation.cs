using System.Collections;
using UnityEngine;

namespace Common {
    
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Detonation : MonoBehaviour, ICacheAble {
        
        [Header("Config")]
        [SerializeField] private GameObject mesh;
        [SerializeField] private ParticleSystem explosion;
        
        [Header("Sound")]
        [SerializeField] private AudioClip explosionClip;
        [SerializeField] private AudioSource audioSource;
               
        private Rigidbody body;
        private bool isDetonated;
        private RigidbodyConstraints constraints;
        
        private void Awake() {
            body = GetComponent<Rigidbody>();
        }

        public void Detonate(bool withExplosionSound = true) {
            if (isDetonated) return;

            if (withExplosionSound) {
                audioSource.PlayOneShot(explosionClip);
            }

            isDetonated = true;
            
            StartCoroutine(SelfDestruction());
        }

        protected virtual void ExplosionTriggered() {
            // Nothing
        }

        protected virtual void ExplosionDone() {
            // Nothing
        }

        public void RestoreFromCache() {
            isDetonated = false;
            body.constraints = constraints;
            mesh.SetActive(true);
        }
        
        private IEnumerator SelfDestruction() {
            constraints = body.constraints;
            body.constraints = RigidbodyConstraints.FreezeAll;

            mesh.SetActive(false);
            explosion.Play();
            
            ExplosionTriggered();
            
            while (explosion.isPlaying) {
                yield return null;
            }
            
            ExplosionDone();
        }

    }
}
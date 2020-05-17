using UnityEngine;

namespace Player {

    [RequireComponent(typeof(Rigidbody))]
    public class WeaponSystem : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Vector3 spawnPoint = new Vector3(0, 0.465f, 0);
        [SerializeField] private new ParticleSystem particleSystem;
        [SerializeField] private float shootForce;

        [Header("Sounds")]
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float chargePitch = 1.5f;
        [SerializeField] private AudioClip chargeClip;
        [SerializeField] private float firePitch = 1f;
        [SerializeField] private AudioClip fireClip;
        
        public float MaxCharge => particleSystem.main.duration;
        public float ChargeBonus => Mathf.Clamp(charging, 0, MaxCharge);
        
        private float charging;
        private Rigidbody body;

        private void Awake() {
            body = GetComponent<Rigidbody>();
        }

        private void Update() {
            if (Input.GetButtonDown("Fire1")) {
                particleSystem.Play();
                audioSource.pitch = chargePitch;
                audioSource.PlayOneShot(chargeClip);
            }

            if (Input.GetButton("Fire1")) {
                charging += Time.deltaTime;
            }

            if (charging > MaxCharge) {
                audioSource.Stop();
            }
            
            if (Input.GetButtonUp("Fire1") || Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
                audioSource.Stop();
                audioSource.pitch = firePitch;
                audioSource.PlayOneShot(fireClip);
                
                var ownTransform = transform;
                var bullet = Instantiate(bulletPrefab, ownTransform.position + spawnPoint, ownTransform.rotation);

                bullet.ChargeBonus = ChargeBonus;
                particleSystem.Stop();
                
                body.velocity = -transform.forward * shootForce;
                
                charging = 0;
            }
        }
    }
    
}
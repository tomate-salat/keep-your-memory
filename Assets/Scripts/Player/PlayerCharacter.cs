using Common;
using UnityEngine;
using UnityEngine.Events;

namespace Player {
    
    [RequireComponent(typeof(WeaponSystem))]
    public class PlayerCharacter : MonoBehaviour, IReactOnDetonation {
        [SerializeField] private UnityEvent onPlayerBlownUp;

        public UnityEvent OnPlayerBlownUp => onPlayerBlownUp;

        private WeaponSystem weaponSystem;

        public bool WeaponSystemActive {
            get => weaponSystem.enabled;
            set => weaponSystem.enabled = value;
        }
        
        private void Awake() {
            weaponSystem = GetComponent<WeaponSystem>();
        }

        public void OnReact() {
            OnPlayerBlownUp.Invoke();
        }
        
    }
}
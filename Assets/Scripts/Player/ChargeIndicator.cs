using UnityEngine;

namespace Player {
    
    public class ChargeIndicator : MonoBehaviour {
        [SerializeField] private WeaponSystem weaponSystem;
        [SerializeField] private Transform innerMemory;
        [SerializeField] private float maxScaleFactor = 1.8f;

        private Vector3 defaultScale;
        private Vector3 maxScale;

        private void Awake() {
            defaultScale = innerMemory.localScale;
            maxScale = defaultScale * maxScaleFactor;
        }

        private void Update() {
            var charged = weaponSystem.ChargeBonus / weaponSystem.MaxCharge;
            innerMemory.localScale = Vector3.Lerp(defaultScale, maxScale, charged);
        }
    }
    
}
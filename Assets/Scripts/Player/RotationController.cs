using System;
using UnityEngine;

namespace Player {
    
    [RequireComponent(typeof(Rigidbody))]
    public class RotationController : MonoBehaviour {

        [Header("Raycast")]
        [SerializeField] private float maxDistance = 100;
        [SerializeField] private LayerMask groundMask;

        private Rigidbody _rigidbody;

        private void Awake() {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate() {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit, maxDistance, groundMask)) {
                var rotation  = Quaternion.LookRotation(hit.point - _rigidbody.position, Vector3.up);
                _rigidbody.rotation = rotation;
                _rigidbody.rotation = Quaternion.Euler(0, _rigidbody.rotation.eulerAngles.y, 0);
            }

        }
    }
    
}
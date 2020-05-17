using UnityEngine;
using UnityEngine.Events;

namespace Level {

    [RequireComponent(typeof(Rigidbody))]
    public class ClockHand : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private int segments;
        [SerializeField] private float speed = 1;
        [SerializeField] private float secondsPerSegment = 1;
        [SerializeField] private Collider fullHourTrigger;

        [Header("Events")]
        [SerializeField] private UnityEvent onFullHour;
        
        public bool MoveOrdinary => Time.time > reachedStart;
        public UnityEvent OnFullHour => onFullHour;
        
        private Rigidbody body;
        
        private bool moveToStart;
        private float reachedStart;
        private Quaternion degreesToStart;
        private Vector3 initialRotation;

        private void Awake() {
            body = GetComponent<Rigidbody>();
            body.centerOfMass = Vector3.zero;
            initialRotation = transform.forward;
        }

        private void FixedUpdate() {
            if (MoveOrdinary) {
                OrdinaryRotation();
            } else {
                ToStartRotation();
            }
        }

        public void MoveToStart() {
            if (!MoveOrdinary) return;
            
            reachedStart = Time.time + 1f;
            degreesToStart = Quaternion.FromToRotation(transform.forward, initialRotation);
        }

        private void ToStartRotation() {
            body.rotation *= Quaternion.Euler(degreesToStart.eulerAngles * Time.deltaTime);
        }
        
        private void OrdinaryRotation() {
            var degreesPerSegment = 360 / segments;
            var updateStep = degreesPerSegment * speed / secondsPerSegment * Time.deltaTime;

            var rotation = body.rotation;
            var eulerAngles = rotation.eulerAngles;
            eulerAngles.y += updateStep;

            body.position = Vector3.zero;
            body.rotation = Quaternion.Euler(0, eulerAngles.y, 0);
        }

        private void OnTriggerExit(Collider other) {
            if (MoveOrdinary && other == fullHourTrigger) {
                OnFullHour.Invoke();
            }
        }
    }
    
}
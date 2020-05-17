using UnityEngine;
using UnityEngine.Events;

namespace Level {
    public class Clock : MonoBehaviour {
        [Header("Components")]
        [SerializeField] private ClockHand hours;
        [SerializeField] private ClockHand minutes;

        [Header("Events")]
        [SerializeField] private UnityEvent onFullHour;
        
        public bool OrdinaryMode => hours.MoveOrdinary && minutes.MoveOrdinary;
        public UnityEvent OnFullHour => onFullHour;

        public void MoveToStart() {
            hours.MoveToStart();
            minutes.MoveToStart();
        }

        public void TriggerFullHour() {
            OnFullHour.Invoke();
        }
        
    }
}
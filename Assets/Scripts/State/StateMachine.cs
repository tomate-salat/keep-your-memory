using System;
using UnityEngine;

namespace State {
    public abstract class StateMachine<TInitState, TData> : MonoBehaviour, INextProvider<TData> where TInitState: AState<TData>, new() {
        [SerializeField] private bool initOnStart;
        [SerializeField] private TData data;
     
        protected AState<TData> State { get; private set; }
        protected TData Data => data;

        private void Awake() {
            if (!initOnStart) {
                Next<TInitState>();
            }
        }

        private void Start() {
            if (initOnStart) {
                Next<TInitState>();
            }
        }

        public void Next<T>() where T : AState<TData>, new() {
            State?.OnExit();
            State?.RemoveListeners();

            State = new T {
                Data = data,
                NextProvider = this,
                StateMachine = this
            };
            
            State.OnEnter();
        }
    }
    
}
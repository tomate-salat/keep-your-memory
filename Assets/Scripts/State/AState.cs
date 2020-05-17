using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace State {
    public abstract class AState<TData> : INextProvider<TData> {
        private readonly AutoListener autoListener = new AutoListener();

        public TData Data { get; set; }
        public INextProvider<TData> NextProvider;
        public MonoBehaviour StateMachine { get; set; }
        
        public virtual void OnEnter() { }
        public virtual void OnExit() { }

        public void Next<T>() where T : AState<TData>, new() {
            NextProvider.Next<T>();
        }

        protected Coroutine StartCoroutine(IEnumerator routine) {
            return StateMachine.StartCoroutine(routine);
        }

        protected void StopCoroutine(Coroutine coroutine) {
            StateMachine.StopCoroutine(coroutine);
        }

        protected void StopAllCoroutines() {
            StateMachine.StopAllCoroutines();
        }
        
        public void Listen(UnityEvent unityEvent, UnityAction action) {
            autoListener.Listen(unityEvent, action);
        }

        public void Listen<T>(UnityEvent<T> unityEvent, UnityAction<T> action) {
            autoListener.Listen(unityEvent, action);
        }

        public void Listen<T1, T2>(UnityEvent<T1, T2> unityEvent, UnityAction<T1, T2> action) {
            autoListener.Listen(unityEvent, action);
        }

        public void Listen<T1, T2, T3>(UnityEvent<T1, T2, T3> unityEvent, UnityAction<T1, T2, T3> action) {
            autoListener.Listen(unityEvent, action);
        }

        public void Listen<T1, T2, T3, T4>(UnityEvent<T1, T2, T3, T4> unityEvent, UnityAction<T1, T2, T3, T4> action) {
            autoListener.Listen(unityEvent, action);
        }

        public void RemoveListeners() {
            autoListener.RemoveListeners();
        }
        
    }
}
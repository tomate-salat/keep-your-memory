using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace State {
    public class AutoListener {
        private readonly List<UnityAction> removers = new List<UnityAction>();

        public void Listen(UnityEvent unityEvent, UnityAction action) {
            unityEvent.AddListener(action);
            
            removers.Add(() => unityEvent.RemoveListener(action));
        }

        public void Listen<T>(UnityEvent<T> unityEvent, UnityAction<T> action) {
            unityEvent.AddListener(action);
            
            removers.Add(() => unityEvent.RemoveListener(action));
        }

        public void Listen<T1, T2>(UnityEvent<T1, T2> unityEvent, UnityAction<T1, T2> action) {
            unityEvent.AddListener(action);
            
            removers.Add(() => unityEvent.RemoveListener(action));
        }

        public void Listen<T1, T2, T3>(UnityEvent<T1, T2, T3> unityEvent, UnityAction<T1, T2, T3> action) {
            unityEvent.AddListener(action);
            
            removers.Add(() => unityEvent.RemoveListener(action));
        }

        public void Listen<T1, T2, T3, T4>(UnityEvent<T1, T2, T3, T4> unityEvent, UnityAction<T1, T2, T3, T4> action) {
            unityEvent.AddListener(action);
            
            removers.Add(() => unityEvent.RemoveListener(action));
        }
        
        public void RemoveListeners() {
            removers.ForEach(remover => remover());
            removers.Clear();
        }
        
    }
}
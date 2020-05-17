using UnityEngine;

namespace Common {
    public class CacheAble : MonoBehaviour {

        public void Restore() {
            foreach (var cache in GetComponentsInChildren<ICacheAble>()) {
                cache.RestoreFromCache();
            }
        }
        
    }
}
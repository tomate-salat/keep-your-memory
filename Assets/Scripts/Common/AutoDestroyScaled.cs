using System.Collections;
using UnityEngine;

namespace Common {

    public class AutoDestroyScaled : MonoBehaviour {
        [SerializeField] private float afterSeconds = 2;
        [SerializeField] private float scaleSpeed = 1;

        private IEnumerator Start() {
            yield return new WaitForSeconds(afterSeconds);

            while (Vector3.Max(Vector3.zero, transform.localScale).magnitude > 0.1f) {
                transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
                yield return null;
            }
            
            Destroy(gameObject);
        }
    }
    
}
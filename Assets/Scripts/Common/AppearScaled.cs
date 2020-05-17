using System.Collections;
using UnityEngine;

namespace Common {
    
    public class AppearScaled : MonoBehaviour {
        [SerializeField] private float speed = 2f;

        private IEnumerator Start() {
            transform.localScale = Vector3.zero;

            while (Vector3.Max(Vector3.zero, transform.localScale).magnitude < 1f) {
                transform.localScale += Vector3.one * Time.deltaTime * speed;
                yield return null;
            }
            
            transform.localScale = Vector3.one;
        }
    }
    
}
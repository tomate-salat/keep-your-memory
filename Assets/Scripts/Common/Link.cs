using UnityEngine;

namespace Common {
    
    public class Link : MonoBehaviour {
        [SerializeField] private string url;

        public void Open() {
            WebLink.OpenLink(url);
        }
    }
    
}
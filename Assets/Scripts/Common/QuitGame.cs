using UnityEditor;
using UnityEngine;

namespace Common {
    public class QuitGame : MonoBehaviour {

        public void Quit() {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
        
    }
}
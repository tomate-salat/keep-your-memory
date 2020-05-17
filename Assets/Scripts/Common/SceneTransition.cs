using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

namespace Common {
    
    public class SceneTransition : MonoBehaviour {
        [SerializeField] private int gameSceneIndex = 1;
        [SerializeField] private PlayableDirector director;
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float fadeFactor = 1;

        private bool CanSkip => PlayerPrefs.GetInt("intro.shown", 0) == 1;
        
        public void LoadGameScene() {
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvasGroup.gameObject);
            
            director.Stop();
            director.gameObject.SetActive(false);
            canvasGroup.alpha = 1;
            SceneManager.LoadSceneAsync(gameSceneIndex).completed += OnSceneLoaded;
        }

        private void OnSceneLoaded(AsyncOperation obj) {
            StartCoroutine(FadeOut());
        }

        private IEnumerator FadeOut() {
            PlayerPrefs.SetInt("intro.shown", 1);
            PlayerPrefs.Save();
            
            while (canvasGroup.alpha > 0.1f) {
                canvasGroup.alpha -= Time.deltaTime * fadeFactor;
                yield return null;
            }

            Destroy(gameObject);
        }

        private void Update() {
            if (CanSkip && Input.anyKeyDown) {
                LoadGameScene();
            }
        }
        
    }
    
}
using TMPro;
using UnityEngine;

namespace Ui {
    public class FloatingValue : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private float fadeSpeed = 1;
        
        [Header("Components")]
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private TextMeshProUGUI text;

        public int Value {
            set => text.SetText("{0}", value);
        }

        public Color TextColor {
            get => text.color;
            set => text.color = value;
        }
        
        private void Update() {
            if (canvasGroup.alpha > 0) {
                canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
                transform.position += Vector3.up * (moveSpeed * Time.deltaTime);
            } else {
                Destroy(gameObject);
            }
        }
    }
}
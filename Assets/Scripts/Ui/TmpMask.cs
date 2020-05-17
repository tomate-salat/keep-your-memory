using TMPro;
using UnityEngine;

namespace Ui {
    
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TmpMask : MonoBehaviour {
        private TextMeshProUGUI text;
        private string mask;

        public int Value {
            set {
                Init();
                text.SetText(mask, value);
            }
        }

        private void Awake() {
            Init();
        }

        private void Init() {
            if (text == null) {
                text = GetComponent<TextMeshProUGUI>();
                mask = text.text;
            }
        }
    }
}
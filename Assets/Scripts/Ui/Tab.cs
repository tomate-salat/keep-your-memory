using Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ui {

    public class Tab : MonoBehaviour {
        [Header("Config")]
        [SerializeField] private bool selected;
        
        [Header("Colors")]
        [SerializeField] private Color active;
        [SerializeField] private Color inactive;

        [Header("Components")] 
        [SerializeField] private Button button;

        [SerializeField] private Image image;
        [SerializeField] private GameObject content;

        [Header("Events")]
        [SerializeField] private BoolEvent onChange;

        public bool Selected {
            get => selected;
            set {
                if (selected == value) return;

                selected = value;
                OnChange.Invoke(selected);
                UpdateState();
            }
        }

        public BoolEvent OnChange => onChange;
        public UnityEvent OnClick => button.onClick;

        private void OnEnable() {
            UpdateState();
        }

        private void UpdateState() {
            if (!isActiveAndEnabled) return;
            
            content.SetActive(selected);
            image.color = selected ? active : inactive;
        }
        
    }
    
}
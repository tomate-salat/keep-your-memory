using State;
using UnityEngine;

namespace Ui {
    
    public class TabView : MonoBehaviour {
        [SerializeField] private int defaultSelection;

        private Tab[] tabs;
        private Tab activeTab;

        private readonly AutoListener autoListener = new AutoListener(); 
        
        private void Awake() {
            tabs = GetComponentsInChildren<Tab>();

            for (var i = 0; i < tabs.Length; i++) {
                var tab = tabs[i];
                
                tab.Selected = i == defaultSelection;
                autoListener.Listen(tab.OnClick, () => Show(tab));

                if (tab.Selected) {
                    activeTab = tab;
                }
            }
        }

        private void OnDestroy() {
            autoListener.RemoveListeners();
        }

        public void Select(int index) {
            Show(tabs[index]);
        }
        
        private void Show(Tab tab) {
            if (tab == activeTab) return;

            activeTab.Selected = false;
            activeTab = tab;
            activeTab.Selected = true;
        }
    }
    
}
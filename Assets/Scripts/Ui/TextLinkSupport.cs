using Common;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Ui {
    public class TextLinkSupport : MonoBehaviour, IPointerClickHandler {
        [SerializeField] private TextMeshProUGUI text;
        
        public void OnPointerClick(PointerEventData eventData) {
            var index = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, null);

            if (index != -1) {
                var info = text.textInfo.linkInfo[index];
                WebLink.OpenLink(info.GetLinkID());
            }
        }
        
    }
}
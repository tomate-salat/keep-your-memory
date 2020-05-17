#if UNITY_WEBGL
using System.Runtime.InteropServices;
#endif

using UnityEngine;

namespace Common {
    public static class WebLink {
        public static void OpenLink(string link) {
#if UNITY_WEBGL
                OpenLinkInTab(link);
#else
            Application.OpenURL(link);
#endif
        }
#if UNITY_WEBGL 
        [DllImport("__Internal")]
        private static extern void OpenLinkInTab(string url);
#endif
    }
}
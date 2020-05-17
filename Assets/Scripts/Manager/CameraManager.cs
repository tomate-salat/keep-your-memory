using Cinemachine;
using UnityEngine;

namespace Manager {
    
    public class CameraManager : MonoBehaviour {
        [SerializeField] private CinemachineVirtualCamera playerCam;
        
        public void SetFollowTarget(Transform target) {
            playerCam.Follow = target;
            playerCam.LookAt = target;
        }
    }
    
}
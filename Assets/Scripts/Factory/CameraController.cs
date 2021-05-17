using System;
using Cinemachine;
using UnityEngine;

namespace Factory
{
    public class CameraController : MonoBehaviour
    {
        private const int activePriority = 10;
        private const int inactivePriority = 0;

        [SerializeField] private CinemachineVirtualCamera[] cameras;
        private int cameraIndex;

        private CinemachineVirtualCamera current => cameras[cameraIndex];

        private void Start()
        {
            SetCameraAlone(current);
        }

        private void SetCameraActive(CinemachineVirtualCamera vcam, bool state)
        {
            vcam.Priority = state ? activePriority : inactivePriority;
        }

        private void SetCameraAlone(CinemachineVirtualCamera vcam)
        {
            foreach (var cam in cameras)
                SetCameraActive(cam, false);
            SetCameraActive(vcam, true);
        }

        public void SetNextCamera()
        {
            cameraIndex = (cameraIndex + 1) % cameras.Length;
            SetCameraAlone(current);
        }
        
        public void SetTarget(Transform target)
        {
            current.LookAt = target;
        }
    }
}
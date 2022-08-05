using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

namespace _Project.Scripts
{
    [Serializable]
    public class Cam
    {
        public CinemachineVirtualCamera VirtualCamera;
        public float TransitionDistance;
    }
    
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private List<Cam> _cameras = new List<Cam>();
        [SerializeField] private CinemachineSmoothPath _cameraPath;
        [SerializeField] private CinemachineVirtualCamera _trackedVirtualCamera;
        
        private CinemachineTrackedDolly _trackedDolly;
        private CinemachineVirtualCamera _currentCam;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            FollowTarget();
            FindClosestCamera();
        }

        private void Initialize()
        {
            _trackedDolly = _trackedVirtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
            _currentCam = _cameras[0].VirtualCamera;
        }

        private void FollowTarget()
        {
            float pos = _cameraPath.FindClosestPoint(_target.position, 0, -1, 10);
            _trackedDolly.m_PathPosition = pos;
        }

        private void FindClosestCamera()
        {
            CinemachineVirtualCamera closestCamera = GetClosestCamera();
            
            if (_currentCam != closestCamera)
            {
                _currentCam.Priority = 0;
                closestCamera.Priority = 10;
                _currentCam = closestCamera;
            }
        }

        private CinemachineVirtualCamera GetClosestCamera()
        {
            CinemachineVirtualCamera closestCamera = null;
            float closestDistance = 9999;
            
            foreach (Cam cam in _cameras)
            {
                float distance = Vector3.Distance(cam.VirtualCamera.transform.position, _target.position);
                distance -= cam.TransitionDistance;

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestCamera = cam.VirtualCamera;
                }
            }

            return closestCamera;
        }
    }
}

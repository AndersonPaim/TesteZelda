using UnityEngine;
using Cinemachine;

namespace _Project.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private CinemachineVirtualCamera _virtualCamera;
        private CinemachineTrackedDolly _trackedDolly;
        private CinemachineSmoothPath _path;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            FollowTarget();
        }

        private void Initialize()
        {
            _path = GetComponent<CinemachineSmoothPath>();
            _trackedDolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        }

        private void FollowTarget()
        {
            float pos = _path.FindClosestPoint(_target.position, 0, -1, 10);
            _trackedDolly.m_PathPosition = pos;
        }
    }
}

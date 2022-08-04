using _Project.Scripts.Events;
using Coimbra.Services.Events;
using UnityEngine;

namespace _Project.Scripts
{
    public class Crate : MonoBehaviour
    {
        private Player _grabber;
        private bool _canGrab = false;
        private bool _isGrabbing = false;
    
        public void OnStart()
        {
            SetupEvents();
        }

        public void OnUpdate()
        {
            GroundCheck();
        }

        public void Destroy()
        {
            DestroyEvents();
        }

        private void SetupEvents()
        {
            OnGrab.AddListener(Grab);
        }

        private void DestroyEvents()
        {
            OnGrab.RemoveAllListeners();
        }

        private void GroundCheck()
        {
            bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.3f);
            Rigidbody rb = GetComponent<Rigidbody>();

            if (!isGrounded && rb == null)
            {
                rb = gameObject.AddComponent<Rigidbody>();
                rb.freezeRotation = true;
                rb.drag = 5;
            }
        }

        private void Grab(ref EventContext context, in OnGrab e)
        {
            if (!_canGrab)
            {
                return;
            }
            
            if (_isGrabbing)
            {
                StopGrabbingObject();
            }
            else
            {
                StartGrabbingObject();
            }
        }

        private void StartGrabbingObject()
        {
            _isGrabbing = true;
            _grabber.StartGrabbing();
            gameObject.transform.SetParent(_grabber.transform);
        }

        private void StopGrabbingObject()
        {
            gameObject.transform.SetParent(null);
            _grabber.StopGrabbing();
            _isGrabbing = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player == null)
            {
                return;
            }
        
            _canGrab = true;
            _grabber = player;
        }

        private void OnTriggerExit(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player == null)
            {
                return;
            }
            
            StopGrabbingObject();
        }
    }
}

using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour
    {
        private Rigidbody _rb;
        private bool _isGrounded = true;
        
        public void OnStart()
        {
            Initialize();
        }

        public void OnUpdate()
        {
            GroundCheck();
        }
        
        public void Move(Vector2 moveDirection)
        {
            float turnVelocity = 15;
            
            Vector3 direction = new Vector3(moveDirection.x, _rb.velocity.y, moveDirection.y).normalized;
            
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
                targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, 0.03f);
                transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                
                direction = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                direction *= 3; //TODO GET PLAYER SPEED
                direction.y = _rb.velocity.y;
                _rb.velocity = direction;
            }
        }
        
        public void Jump()
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
        }
        
        public void Interact()
        {
            Debug.Log("INTERACT");
        }

        private void Initialize()
        {
            _rb = GetComponent<Rigidbody>();
        }
        
        private void GroundCheck()
        {
            _isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.3f);
        }
    }
}

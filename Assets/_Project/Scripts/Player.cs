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
            moveDirection *= 8; //TODO GET PLAYER SPEED
            Vector3 rightDirection = transform.right;
            Vector3 playerDirection = new Vector3(-rightDirection.z, 0, rightDirection.x);
            Vector3 movementDirection = (playerDirection * moveDirection.y + rightDirection * moveDirection.x);
            movementDirection.y = _rb.velocity.y;
            _rb.velocity = movementDirection;
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

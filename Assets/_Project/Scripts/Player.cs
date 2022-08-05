using _Project.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerBalancer _playerBalancer;
        [SerializeField] private Transform _walkDirection;
        
        private Rigidbody _rb;
        private CapsuleCollider _collider;
        private bool _isGrounded = true;
        private bool _isGrabbing = false;
        private float _moveSpeed;

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
            if (_isGrabbing)
            {
                GrabMovement(moveDirection.y);
            }
            else
            {
                PlayerMovement(moveDirection);
            }
        }
        
        public void Jump()
        {
            if (_isGrounded)
            {
                _animator.SetTrigger("Jump");
                _rb.AddForce(Vector3.up * _playerBalancer.JumpForce, ForceMode.Impulse);
            }
        }
        
        public void Crouch(bool isCrouching)
        {
            if (isCrouching)
            {
                _moveSpeed = _playerBalancer.CrouchMoveSpeed;
                _collider.center = new Vector3(0, -0.4f, 0);
                _collider.height = 1.2f;
            }
            else
            {
                _moveSpeed = _playerBalancer.MoveSpeed;
                _collider.center = Vector3.zero;
                _collider.height = 2f;
            }
            
            _animator.SetBool("IsCrouching", isCrouching);
        }
        
        public void StartGrabbing()
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            _moveSpeed = _playerBalancer.GrabMoveSpeed;
            _isGrabbing = true;
            _animator.SetBool("IsPushing", true);
        }
        
        public void StopGrabbing()
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            _moveSpeed = _playerBalancer.MoveSpeed;
            _isGrabbing = false;
            _animator.SetBool("IsPushing", false);
        }

        private void Initialize()
        {
            _collider = GetComponent<CapsuleCollider>();
            _rb = GetComponent<Rigidbody>();
            _moveSpeed = _playerBalancer.MoveSpeed;
        }

        private void PlayerMovement(Vector2 moveDirection)
        {
            Vector3 direction = new Vector3(moveDirection.x, 0, moveDirection.y).normalized;

            if (direction.magnitude < 0.1f)
            {
                _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
                _animator.SetBool("IsMoving", false);
                return;
            }
            
            _animator.SetBool("IsMoving", true);
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg + _walkDirection.eulerAngles.y;
            targetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _playerBalancer.TurnVelocity, 0.05f);
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
                
            direction = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            direction *= _moveSpeed;
            direction.y = _rb.velocity.y;
            _rb.velocity = direction;
        }

        private void GrabMovement(float direction)
        {
            _animator.SetBool("IsMoving", direction != 0);
            _animator.SetFloat("GrabWalkSpeed", direction);

            direction *= _moveSpeed;
            Vector3 right = gameObject.transform.right;
            Vector3 dir = new Vector3(-right.z, 0, right.x);
            Vector3 movementDir = (dir * direction + right * 0);
            _rb.velocity = movementDir;
        }
        
        private void GroundCheck()
        {
            _isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.3f);
            _animator.SetBool("IsGrounded", _isGrounded);
        }
    }
}

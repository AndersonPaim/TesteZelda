using UnityEngine;

namespace _Project.Scripts.Manager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        private PlayerInputActions _input;
        
        public void OnStart()
        {
            SetupEvents();
            _input.Enable();
        }

        public void OnUpdate()
        {
            Movement();
        }
        
        private void SetupEvents()
        {
            _input = new PlayerInputActions();
            _input.Player.Jump.performed += _ => Jump();
            _input.Player.Interact.performed += _ => Interact();
            _input.Player.Crouch.performed += _ => Crourch(true);
            _input.Player.Crouch.canceled += _ => Crourch(false);
        }
        
        private void Movement()
        {
            _player.Move(_input.Player.Movement.ReadValue<Vector2>());
        }

        private void Jump()
        {
            _player.Jump();
        }

        private void Interact()
        {
            _player.Interact();
        }
        
        private void Crourch(bool isCrouching)
        {
            _player.Crouch(isCrouching);
        }
    }
}

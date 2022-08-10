using System;
using _Project.Scripts.Events;
using Coimbra.Services;
using Coimbra.Services.Events;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Manager
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private Player _player;
        
        private PlayerInputActions _input;
        private IEventService _eventService;
        
        public void OnStart()
        {
            SetupEvents();
            _input.Enable();
            _eventService = ServiceLocator.Get<IEventService>();
        }

        public void OnUpdate()
        {
            Movement();
        }

        private void OnDestroy()
        {
            DestroyEvents();
        }

        private void SetupEvents()
        {
            _input = new PlayerInputActions();
            _input.Player.Jump.performed += Jump;
            _input.Player.Grab.performed += Grab;
            _input.Player.Crouch.performed += Crourch;
            _input.Player.Crouch.canceled += Crourch;
        }

        private void DestroyEvents()
        {
            _input.Player.Jump.performed -= Jump;
            _input.Player.Grab.performed -= Grab;
            _input.Player.Crouch.performed -= Crourch;
            _input.Player.Crouch.canceled -= Crourch;
        }
        
        private void Movement()
        {
            _player.Move(_input.Player.Movement.ReadValue<Vector2>());
        }

        private void Jump(InputAction.CallbackContext ctx)
        {
            _player.Jump();
        }

        private void Grab(InputAction.CallbackContext ctx)
        {
            OnGrab grab = new OnGrab();
            grab?.Invoke(_eventService);
        }
        
        private void Crourch(InputAction.CallbackContext ctx)
        {
            if (ctx.performed)
            {
                _player.Crouch(true);
            }
            else
            {
                _player.Crouch(false);
            }
        }
    }
}

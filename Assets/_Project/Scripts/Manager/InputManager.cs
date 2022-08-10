using System;
using _Project.Scripts.Events;
using Coimbra.Services;
using Coimbra.Services.Events;
using UnityEngine;

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

        private void SetupEvents()
        {
            _input = new PlayerInputActions();
            _input.Player.Jump.performed += _ => Jump();
            _input.Player.Grab.performed += _ => Grab();
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

        private void Grab()
        {
            OnGrab grab = new OnGrab();
            grab?.Invoke(_eventService);
        }
        
        private void Crourch(bool isCrouching)
        {
            _player.Crouch(isCrouching);
        }
    }
}

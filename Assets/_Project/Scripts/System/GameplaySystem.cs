using System;
using System.Collections.Generic;
using _Project.Scripts.Manager;
using UnityEngine;

namespace _Project.Scripts.System
{
    public class GameplaySystem : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Player _player;
        [SerializeField] private List<Crate> _crates = new List<Crate>();
        
        private void Start()
        {
            _inputManager.OnStart();
            _player.OnStart();
            
            foreach (Crate crate in _crates)
            {
                crate.OnStart();
            }
            
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            _inputManager.OnUpdate();
            _player.OnUpdate();
            
            foreach (Crate crate in _crates)
            {
                crate.OnUpdate();
            }
        }

        private void OnDestroy()
        {
            foreach (Crate crate in _crates)
            {
                crate.Destroy();
            }
        }
    }
}

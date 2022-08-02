using _Project.Scripts.Manager;
using UnityEngine;

namespace _Project.Scripts.System
{
    public class GameplaySystem : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private Player _player;
        
        private void Start()
        {
            _inputManager.OnStart();
            _player.OnStart();
        }

        private void Update()
        {
            _inputManager.OnUpdate();
            _player.OnUpdate();
        }
    }
}

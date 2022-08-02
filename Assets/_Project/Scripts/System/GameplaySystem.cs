using _Project.Scripts.Manager;
using UnityEngine;

namespace _Project.Scripts.System
{
    public class GameplaySystem : MonoBehaviour
    {
        [SerializeField] private InputManager _inputManager;
        
        private void Start()
        {
            _inputManager.OnStart();
        }

        private void Update()
        {
            _inputManager.OnUpdate();
        }
    }
}

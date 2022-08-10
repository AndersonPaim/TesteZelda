using _Project.Scripts.Events;
using Coimbra.Services;
using Coimbra.Services.Events;
using UnityEngine;

namespace _Project.Scripts
{
    public class LevelFinishTrigger : MonoBehaviour
    {
        private IEventService _eventService;
        
        public void OnStart()
        {
            Initialize();
        }

        private void Initialize()
        {
            _eventService = ServiceLocator.Get<IEventService>();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                OnLevelCompleted levelCompleted = new OnLevelCompleted();
                levelCompleted?.Invoke(_eventService);
            }
        }
    }
}

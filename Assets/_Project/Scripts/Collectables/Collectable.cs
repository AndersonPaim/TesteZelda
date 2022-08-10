using System;
using _Project.Scripts.Events;
using Coimbra;
using Coimbra.Services;
using Coimbra.Services.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private int _scoreAmount;
        [SerializeField] private float _destroyDelay;
        private Collider _collider;
        private Animator _animator;
        private IEventService _eventService;
        
        public void OnStart()
        {
            Initialize();
        }

        private void Initialize()
        {
            _eventService = ServiceLocator.Get<IEventService>();
            _collider = GetComponent<Collider>();
            _animator = GetComponent<Animator>();
        }

        private void CollectItem()
        {
            _animator.SetTrigger("Collect");
            _collider.enabled = false;
            OnCollectGem collectGem = new OnCollectGem() { Score = _scoreAmount };
            collectGem?.Invoke(_eventService);
            DestroyASync();
        }

        private async UniTask DestroyASync()
        {
            await UniTask.Delay((int)(_destroyDelay * 1000));
            gameObject.Destroy();
        }

        private void OnTriggerEnter(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();

            if (player != null)
            {
                CollectItem();
            }
        }
    }
}

using System;
using Coimbra;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Collectables
{
    public class Collectable : MonoBehaviour
    {
        [SerializeField] private float _coinsAmount;
        [SerializeField] private float _destroyDelay;
        private Collider _collider;
        private Animator _animator;
        
        public void OnStart()
        {
            Initialize();
        }

        private void Initialize()
        {
            _collider = GetComponent<Collider>();
            _animator = GetComponent<Animator>();
        }

        private void CollectItem()
        {
            _animator.SetTrigger("Collect");
            _collider.enabled = false;
            DestroyASync();
            //TODO SAVE SCORE
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

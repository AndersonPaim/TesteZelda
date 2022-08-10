using System;
using _Project.Scripts.Enums;
using _Project.Scripts.Events;
using _Project.Scripts.Interfaces;
using Coimbra.Services;
using Coimbra.Services.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameScenes _nextLevel;
        [SerializeField] private GameScenes _previousLevel;
        
        private ISceneLoader _sceneLoader;
        
        public void OnStart()
        {
            SetupEvents();
            Initialize();
        }

        private void OnDestroy()
        {
            DestroyEvents();
        }

        private void Initialize()
        {
            _sceneLoader = ServiceLocator.Get<ISceneLoader>();
        }

        private void SetupEvents()
        {
            OnLevelCompleted.AddListener(LevelCompleted);
            OnAlertEnemy.AddListener(EnemyAlerted);
        }

        private void DestroyEvents()
        {
            OnLevelCompleted.RemoveAllListeners();
            OnAlertEnemy.RemoveAllListeners();
        }

        private void LevelCompleted(ref EventContext context, in OnLevelCompleted e)
        {
            _sceneLoader.LoadScene(_nextLevel.ToString());
        }

        private void EnemyAlerted(ref EventContext context, in OnAlertEnemy e)
        {
            GameOverASync();
        }

        private async UniTask GameOverASync()
        {
            await UniTask.Delay(2000);
            _sceneLoader.LoadScene(_previousLevel.ToString());
        }
    }
}

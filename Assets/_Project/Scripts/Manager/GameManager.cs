using System;
using _Project.Scripts.Enums;
using _Project.Scripts.Events;
using Coimbra.Services.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace _Project.Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameScenes _nextLevel;
        [SerializeField] private GameScenes _previousLevel;
        
        public void OnStart()
        {
            SetupEvents();
        }

        private void OnDestroy()
        {
            DestroyEvents();
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
            Debug.Log("WON");
        }

        private void EnemyAlerted(ref EventContext context, in OnAlertEnemy e)
        {
            GameOverASync();
        }

        private async UniTask GameOverASync()
        {
            Debug.Log("LOST");
            await UniTask.Delay(2000);
        }
    }
}

using _Project.Scripts.Events;
using Coimbra.Services.Events;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace _Project.Scripts.Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image _sceneTransitionImage;
        
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
            OnGameOver.AddListener(SceneTransition);
        }

        private void DestroyEvents()
        {
            OnGameOver.RemoveAllListeners();
        }

        private void SceneTransition(ref EventContext context, in OnGameOver e)
        {
            _sceneTransitionImage.DOFade(1, 1);
        }
    }
}

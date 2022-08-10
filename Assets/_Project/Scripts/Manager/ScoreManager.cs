using System;
using _Project.Scripts.Events;
using Coimbra.Services;
using Coimbra.Services.Events;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.Scripts.Manager
{
	public class ScoreManager : MonoBehaviour
	{
		private IEventService _eventService;
		private int _score = 0;

		public void OnStart()
		{
			Initialize();
			SetupEvents();
		}

		public void OnDestroy()
		{
			DestroyEvents();
		}

		private void Initialize()
		{
			_eventService = ServiceLocator.Get<IEventService>();
		}

		private void SetupEvents()
		{
			OnCollectGem.AddListener(AddScore);
		}

		private void DestroyEvents()
		{
			OnCollectGem.RemoveAllListeners();
		}
		
		private void AddScore(ref EventContext context, in OnCollectGem e)
		{
			_score += e.Score;
			OnUpdateScore updateScore = new OnUpdateScore() { Score = _score };
			updateScore?.Invoke(_eventService);
		}
	}
}
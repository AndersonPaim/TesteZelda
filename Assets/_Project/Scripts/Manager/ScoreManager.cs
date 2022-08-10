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
		public Action<int> OnUpdateScore;
		
		private int _score = 0;

		public void OnStart()
		{
			SetupEvents();
		}

		public void OnDestroy()
		{
			DestroyEvents();
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
			OnUpdateScore?.Invoke(_score);
		}
	}
}
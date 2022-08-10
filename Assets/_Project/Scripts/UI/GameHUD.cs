using System;
using _Project.Scripts.Enums;
using _Project.Scripts.Events;
using _Project.Scripts.Manager;
using Coimbra.Services.Events;
using UnityEngine;
using TMPro;

namespace _Project.Scripts.UI
{
	public class GameHUD : MonoBehaviour
	{
		[SerializeField] private ScoreManager _scoreManager;
		[SerializeField] private TextMeshProUGUI _playerActionText;
		[SerializeField] private TextMeshProUGUI _scoreText;
		
		private IEventService _eventService;

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
			OnChangePlayerState.AddListener(PlayerActionChanged);
			_scoreManager.OnUpdateScore += UpdateScore;
		}

		private void DestroyEvents()
		{
			OnChangePlayerState.RemoveAllListeners();
			_scoreManager.OnUpdateScore -= UpdateScore;
		}
		
		private void PlayerActionChanged(ref EventContext context, in OnChangePlayerState e)
		{
			switch (e.State)
			{
				case PlayerState.GRAB:
					_playerActionText.text = "GRAB";
					break;
				case PlayerState.CROUCH:
					_playerActionText.text = "CROUCH";
					break;
				case PlayerState.NONE:
					_playerActionText.text = "";
					break;
			}
		}

		private void UpdateScore(int score)
		{
			_scoreText.text = score.ToString();
		}
	}
}
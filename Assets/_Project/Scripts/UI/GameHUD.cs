using _Project.Scripts.Events;
using Coimbra.Services.Events;
using UnityEngine;
using TMPro;

namespace _Project.Scripts.UI
{
	public class GameHUD : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _playerActionText;
		
		private IEventService _eventService;

		public void OnStart()
		{
			SetupEvents();
		}

		private void SetupEvents()
		{
			OnChangePlayerState.AddListener(PlayerActionChanged);
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
	}
}
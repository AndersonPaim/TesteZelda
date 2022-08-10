using _Project.Scripts.Manager;
using UnityEngine;

namespace _Project.Scripts.System
{
	public class GameplaySystemBase : MonoBehaviour
	{
		[SerializeField] private InputManager _inputManager;
		[SerializeField] private GameManager _gameManager;
		[SerializeField] private LevelFinishTrigger _levelFinishTrigger;
		[SerializeField] private Player _player;
		
		protected virtual void Start()
		{
			_inputManager.OnStart();
			_player.OnStart();
			_gameManager.OnStart();
			_levelFinishTrigger.OnStart();
			Cursor.lockState = CursorLockMode.Locked;
		}

		protected virtual void Update()
		{
			_inputManager.OnUpdate();
			_player.OnUpdate();
		}
	}
}
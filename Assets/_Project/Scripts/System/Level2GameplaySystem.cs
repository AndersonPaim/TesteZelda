using _Project.Scripts.Manager;
using UnityEngine;

namespace _Project.Scripts.System
{
	public class Level2GameplaySystem : GameplaySystemBase
	{
		[SerializeField] private CameraManager _cameraManager;
		[SerializeField] private EnemiesManager _enemiesManager;
		[SerializeField] private CollectablesManager _collectablesManager;
		[SerializeField] private ScoreManager _scoreManager;
		
		private void Awake()
		{
			_enemiesManager.OnAwake();
		}
        
		protected override void Start()
		{
			base.Start();
			_cameraManager.OnStart();
			_collectablesManager.OnStart();
			_scoreManager.OnStart();
		}

		protected override void Update()
		{         
			base.Update();
			_cameraManager.OnUpdate();
			_enemiesManager.OnUpdate();
		}
	}
}
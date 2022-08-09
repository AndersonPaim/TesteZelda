using System.Collections.Generic;
using _Project.Scripts.Enemy;
using UnityEngine;

namespace _Project.Scripts.System
{
	public class Level2GameplaySystem : GameplaySystemBase
	{
		[SerializeField] private CameraManager _cameraManager;
		[SerializeField] private List<SkeletonAI> _enemies = new List<SkeletonAI>();

		private void Awake()
		{
			foreach (SkeletonAI enemy in _enemies)
			{
				enemy.OnAwake();
			}
		}
        
		protected override void Start()
		{
			base.Start();
			_cameraManager.OnStart();
		}

		protected override void Update()
		{         
			base.Update();
			_cameraManager.OnUpdate();
			
			foreach (SkeletonAI enemy in _enemies)
	            {
            		enemy.OnUpdate();
	            }
		}
	}
}
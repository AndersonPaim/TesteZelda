using System.Collections.Generic;
using _Project.Scripts.Enemy;
using UnityEngine;

namespace _Project.Scripts.Manager
{
	public class EnemiesManager : MonoBehaviour
	{
		[SerializeField] private List<SkeletonAI> _enemies = new List<SkeletonAI>();

		public void OnAwake()
		{
			foreach (SkeletonAI enemy in _enemies)
			{
				enemy.OnAwake();
			}
		}
		
		public void OnUpdate()
		{
			foreach (SkeletonAI enemy in _enemies)
			{
				enemy.OnUpdate();
			}
		}
	}
}
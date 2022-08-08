using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Enemy
{
	public class EnemyIdle : StateMachine
	{
		public Action OnExit;
		public Action OnCancel;

		public EnemyIdle(GameObject enemy, GameObject player, NavMeshAgent agent, Animator anim, EnemyBalancer balancer)
			: base(enemy, player, agent, anim, balancer)
		{
		}

		protected override void Enter()
		{
			Agent.speed = Balancer.WalkSpeed;
			ExitIdleASync();
			base.Enter();
			Anim.SetTrigger("Idle");
		}

		protected override void Update()
		{
			base.Update();

			if (CanSeePlayer())
			{ 
				OnCancel?.Invoke();
			}
		}

		private async UniTask ExitIdleASync()
		{
			await UniTask.Delay((int)(Balancer.IdleTime * 1000));
			OnExit?.Invoke();
		}
	}
}
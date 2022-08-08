using _Project.Scripts.Events;
using Coimbra.Services;
using Coimbra.Services.Events;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Enemy
{
	public class EnemyAlerted : StateMachine
	{
		private IEventService _eventService;

		public EnemyAlerted(GameObject enemy, GameObject player, NavMeshAgent agent, Animator anim, EnemyBalancer balancer)
			: base(enemy, player, agent, anim, balancer)
		{
		}

		protected override void Enter()
		{
			Anim.SetTrigger("Alerted");
			_eventService = ServiceLocator.Get<IEventService>();
			OnAlertEnemy alertEnemy = new OnAlertEnemy();
			alertEnemy?.Invoke(_eventService);
			base.Enter();
		}

		protected override void Update()
		{
			base.Update();
			LookAtPlayer();
		}

		private void LookAtPlayer()
		{
			Vector3 playerPos = Player.transform.position;
			Vector3 target = new Vector3(playerPos.x, Enemy.transform.position.y, playerPos.z);
			Enemy.transform.LookAt(target);
		}
	}
}
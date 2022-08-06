using System;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Enemy
{
    public class EnemyMoving : StateMachine
    {
        public Action OnExit;
        private Transform _targetPos;

        public EnemyMoving(GameObject enemy, GameObject player, NavMeshAgent agent, Animator anim, EnemyBalancer balancer, Transform targetPos)
                    : base(enemy, player, agent, anim, balancer)
        {
            _targetPos = targetPos;
        }

        protected override void Enter()
        {
            Agent.speed = Balancer.WalkSpeed;
            Anim.SetTrigger("Walk");
            base.Enter();
        }

        protected override void Update()
        {
            base.Update();
            //TODO LOOK FOR PLAYER
            Move();
        }

        private void Move()
        {
            Vector3 position = _targetPos.position;
            Agent.SetDestination(position);
            float targetDistance = Vector3.Distance(Enemy.transform.position, position);

            if(targetDistance < 1)
            {
                OnExit?.Invoke();
            }
        }
    }
}
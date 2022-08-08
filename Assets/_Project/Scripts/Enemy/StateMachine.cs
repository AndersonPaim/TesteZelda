using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Enemy
{
    public class StateMachine
    {
        public Events Stage;
        public StateMachine StateMachineNextState;
        protected GameObject Enemy;
        protected GameObject Player;
        protected NavMeshAgent Agent;
        protected Animator Anim;
        protected EnemyBalancer Balancer;

        public StateMachine Process()
        {
            if (Stage == Events.ENTER)
            {
                Enter();
            }
            if (Stage == Events.UPDATE)
            {
                Update();
            }
            if (Stage == Events.EXIT)
            {
                Exit();
                return StateMachineNextState;
            }

            return this;
        }

        protected StateMachine(GameObject enemy, GameObject player, NavMeshAgent agent, Animator anim, EnemyBalancer balancer)
        {
            Stage = Events.ENTER;
            Enemy = enemy;
            Agent = agent;
            Anim = anim;
            Player = player;
            Balancer = balancer;
        }

        protected virtual void Enter()
        {
            Stage = Events.UPDATE;
        }

        protected virtual void Update()
        {
            Stage = Events.UPDATE;
        }

        protected virtual void Exit()
        {
            Stage = Events.EXIT;
        }

        protected bool CanSeePlayer()
        {
            Vector3 position = Enemy.transform.position;
            
            if (Vector3.Distance(position, Player.transform.position) < Balancer.ViewDistance)
            {
                if (Physics.Raycast(Enemy.transform.position, (Player.transform.position - position), out RaycastHit hit, Balancer.ViewDistance))
                {
                    Debug.DrawRay(position, (Player.transform.position - position), Color.blue);
                    Player player = hit.collider.gameObject.GetComponent<Player>();

                    return player != null;
                }
            }
            
            return false;
        }
    }
}



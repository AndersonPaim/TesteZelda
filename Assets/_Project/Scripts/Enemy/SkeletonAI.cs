using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class SkeletonAI : EnemyBase
    {
        [SerializeField] private List<Transform> _waypointList = new List<Transform>();
        private int _currentWaypoint = 0;
        
        protected override void Initialize()
        {
            base.Initialize();
            EnemyMoving movingState = new EnemyMoving(gameObject, Player, Agent, Anim, EnemyBalancer, GetNextWaypoint());
            movingState.OnExit += IdleState;
            CurrentState = movingState;
        }

        private void MovingState()
        {
            EnemyMoving movingState = new EnemyMoving(gameObject, Player, Agent, Anim, EnemyBalancer, GetNextWaypoint());
            movingState.OnExit += IdleState;
            ChangeState(movingState);
        }

        private void IdleState()
        {
            EnemyIdle idleState = new EnemyIdle(gameObject, Player, Agent, Anim, EnemyBalancer);
            idleState.OnExit += MovingState;
            ChangeState(idleState);
        }
        
        private void ChangeState(StateMachine state)
        {
            CurrentState.StateMachineNextState = state;
            CurrentState.Stage = Events.EXIT;
        }

        private Transform GetNextWaypoint()
        {
            Transform nextWaypoint = _waypointList[_currentWaypoint];
            
            if (_currentWaypoint + 1 >= _waypointList.Count)
            {
                _currentWaypoint = 0;
            }
            else
            {
                _currentWaypoint++;
            }
            
            return nextWaypoint;
        }
    }
}

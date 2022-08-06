using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Project.Scripts.Enemy
{
    public class EnemyBase : MonoBehaviour
    {
        [SerializeField] protected EnemyBalancer EnemyBalancer;
        [SerializeField] protected GameObject Player;

        protected NavMeshAgent Agent;
        protected Animator Anim;
        protected StateMachine CurrentState;
        
        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            CurrentState = CurrentState.Process();
        }

        protected virtual void Initialize()
        {
            Anim = GetComponent<Animator>();
            Agent = GetComponent<NavMeshAgent>();
        }
    }
}


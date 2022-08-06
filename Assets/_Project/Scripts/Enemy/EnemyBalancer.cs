using UnityEngine;

namespace _Project.Scripts.Enemy
{
    [CreateAssetMenu(fileName = "New EnemyBalancer", menuName = "EnemyBalancer")]
    public class EnemyBalancer : ScriptableObject
    {
        public float WalkSpeed;
        public float IdleTime;
    }
}
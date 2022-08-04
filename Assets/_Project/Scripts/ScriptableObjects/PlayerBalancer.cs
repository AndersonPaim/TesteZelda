using UnityEngine;

namespace _Project.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New PlayerBalancer", menuName = "PlayerBalancer")]
    public class PlayerBalancer : ScriptableObject
    {
        public float MoveSpeed;
        public float CrouchMoveSpeed;
        public float GrabMoveSpeed;
        public float JumpForce;
        public float TurnVelocity;
    }
}
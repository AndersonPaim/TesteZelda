using UnityEngine;

namespace _Project.Scripts
{
    public class Player : MonoBehaviour
    {
        public void Move(Vector2 moveDirection)
        {
            Debug.Log("MOVE: " + moveDirection);
        }
        
        public void Jump()
        {
            Debug.Log("JUMP");
        }
        
        public void Interact()
        {
            Debug.Log("INTERACT");
        }
    }
}

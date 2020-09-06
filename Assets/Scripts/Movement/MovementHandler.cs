using UnityEngine;

namespace Movement
{
    public class MovementHandler : MonoBehaviour, IMovementHandler
    {
        public float Speed = 5f;
        
        public void OnMove(MovementData movement)
        {
            transform.Translate(movement.Direction * Speed * Time.deltaTime);
        }
    }
}
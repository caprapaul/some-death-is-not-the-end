using UnityEngine;

namespace Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementHandler : MonoBehaviour, IMovementHandler
    {
        public float Speed = 5f;

        private Rigidbody2D _rb;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void OnMove(MovementData movement)
        {
            Vector2 movementDelta = movement.Direction * (Speed * Time.deltaTime);
            Vector2 position = transform.position;
            
            _rb.MovePosition(position + movementDelta);
        }
    }
}
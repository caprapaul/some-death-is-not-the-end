using Spawning;
using UnityEngine;

namespace Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementHandler : MonoBehaviour, IMovementHandler
    {
        public float Speed = 5f;

        private Rigidbody2D _rb;
        private Vector2 _nextYeet = Vector2.zero;
        private DeadBody _deadBody;
        
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _deadBody = GetComponent<DeadBody>();
        }

        public void OnMove(MovementData movement)
        {
            if (_deadBody != null && !_deadBody.IsAlive)
            {
                return;
            }
            
            Vector2 movementDelta = movement.Direction * (Speed * Time.deltaTime);
            Vector2 position = transform.position;

            _rb.MovePosition(position + movementDelta + _nextYeet);
            _nextYeet = Vector2.zero;
        }

        public void GetYeetedFrom(Vector3 pos, float power = 1f)
        {
            Vector2 inverseDelta = (pos - transform.position) * -1;
            _nextYeet = inverseDelta.normalized * power;
        }

        public void GetYeetedFromPlayer()
        {
            if (Player.Current.IsAlive)
            {
                GetYeetedFrom(Player.Current.transform.position);
            }
        }
    }
}
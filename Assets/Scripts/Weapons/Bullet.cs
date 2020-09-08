using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public Vector2 Direction;
        public float Speed = 1f;
        
        private Rigidbody2D _rigid;

        private void Start()
        {
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector3 deltaMove = new Vector3(Direction.x, Direction.y, 0) * (Speed * Time.deltaTime);
            _rigid.MovePosition(transform.position + deltaMove);
        }
    }
}

using System;
using QFSW.MOP2;
using UnityEngine;

namespace Weapons
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public Vector2 Direction;
        public float Speed = 1f;
        public ObjectPool BulletPool;

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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Wall") || other.gameObject.CompareTag("Enemy"))
            {
                enabled = false;
            }
        }

        private void OnDisable()
        {
            BulletPool.Release(gameObject);
        }
    }
}
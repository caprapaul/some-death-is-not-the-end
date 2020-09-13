using System.Collections;
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
        public ParticleSystem ParticleSystem;
        public GameObject Visual;

        private Rigidbody2D _rigid;

        private void Start()
        {
            _rigid = GetComponent<Rigidbody2D>();
        }

        private void OnEnable()
        {
            Visual.gameObject.SetActive(true);
            ParticleSystem.Clear();
            ParticleSystem.Stop();
        }

        private void FixedUpdate()
        {
            Vector3 deltaMove = new Vector3(Direction.x, Direction.y, 0) * (Speed * Time.deltaTime);
            _rigid.MovePosition(transform.position + deltaMove);
        }

        public void KillBullet()
        {
            Speed = 0;
            Visual.gameObject.SetActive(false);
            ParticleSystem.Clear();
            ParticleSystem.Play();
            StartCoroutine(DieInHalfASecond());
        } 

        private IEnumerator DieInHalfASecond()
        {
            yield return new WaitForSeconds(0.5f);
            enabled = false;
        }

        private void OnDisable()
        {
            BulletPool.Release(gameObject);
        }
    }
}
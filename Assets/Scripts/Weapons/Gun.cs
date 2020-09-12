using QFSW.MOP2;
using UnityEngine;

namespace Weapons
{
    public class Gun : MonoBehaviour, IWeapon
    {
        public ObjectPool BulletPool;
        public float ReloadTime = 0.25f;
        public float BulletSpeed = 10f;

        private float _lastShootTime; 
        
        public void Fire(Vector2 initialPosition, Vector2 direction)
        {
            _lastShootTime = Time.time;
            var bullet = BulletPool.GetObjectComponent<Bullet>();
            bullet.Direction = direction.normalized;
            bullet.Speed = BulletSpeed;
            bullet.transform.position = initialPosition;
            bullet.BulletPool = BulletPool;
            bullet.enabled = true;
        }

        public bool CanFire()
        {
            return Time.time > _lastShootTime + ReloadTime;
        }
    }
}

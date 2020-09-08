using UnityEngine;

namespace Weapons
{
    public interface IWeapon
    {
        void Fire(Vector2 initialPosition, Vector2 direction);
        bool CanFire();
    }
}

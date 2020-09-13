using Spawning;
using UnityEngine;

namespace Dead
{
    [RequireComponent(typeof(CircleCollider2D), typeof(DeadBody))]
    public class DisableColliderOnPlayerDeadForAliveEnemies : MonoBehaviour
    {
        private Collider2D _collider;
        private DeadBody _deadBody;

        private void Start()
        {
            _collider = GetComponent<CircleCollider2D>();
            _deadBody = GetComponent<DeadBody>();
        }

        private void Update()
        {
            if (!Player.Current.isAlive && _deadBody.IsAlive)
                _collider.enabled = false;
            else if (Player.Current.isAlive && _deadBody.IsAlive)
                _collider.enabled = true;
            else if (Player.Current.isAlive && !_deadBody.IsAlive)
                _collider.enabled = false;
            else if (!Player.Current.isAlive && !_deadBody.IsAlive)
                _collider.enabled = true;
        }
    }
}
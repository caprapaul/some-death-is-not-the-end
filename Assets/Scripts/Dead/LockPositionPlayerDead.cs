using UnityEngine;

namespace Movements
{
    public class LockPositionPlayerDead : MonoBehaviour
    {
        private Rigidbody2D _rb;
        private RigidbodyConstraints2D _defaultConstraints;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _defaultConstraints = _rb.constraints;
        }

        private void Update()
        {
            _rb.constraints = !Player.Current.IsAlive
                ? RigidbodyConstraints2D.FreezeAll
                : _defaultConstraints;
        }
    }
}
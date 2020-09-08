using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons
{
    [RequireComponent(typeof(Transform))]
    public class MouseDirectionCalculator : MonoBehaviour, GameInputs.IPlayerActions
    {
        public Vector2 Direction { get; private set; } = Vector2.zero;
        private GameInputs _gameInputs;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void OnEnable()
        {
            if (_gameInputs == null)
            {
                _gameInputs = new GameInputs();
                _gameInputs.Player.SetCallbacks(this);
            }

            _gameInputs.Enable();
        }

        private void OnDisable()
        {
            _gameInputs.Disable();
        }

        private void Update()
        {
            Vector3 playerPosition = transform.position;
            Vector3 mousePosition = _camera.ScreenToWorldPoint(_gameInputs.Player.Look.ReadValue<Vector2>());
            Direction = (mousePosition - playerPosition).normalized;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // not used
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            // not used
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            // not used
        }
    }
}
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    [RequireComponent(typeof(IMovementHandler))]
    public class PlayerInputMovement : MonoBehaviour, GameInputs.IPlayerActions
    {
        private MovementData _currentMovement;
        private GameInputs _gameInputs;
        private IMovementHandler _movementHandler;
        
        private void OnEnable()
        {
            if (_gameInputs == null)
            {
                _gameInputs = new GameInputs();
                _gameInputs.Player.SetCallbacks(this);
            }

            _movementHandler = GetComponent<IMovementHandler>();
            _gameInputs.Enable();
        }

        private void OnDisable()
        {
            _gameInputs.Disable();
        }

        private void FixedUpdate()
        {
            _movementHandler.OnMove(_currentMovement);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            _currentMovement.Direction = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            // unused
        }

        public void OnFire(InputAction.CallbackContext context)
        {
            // unused
        }
    }
}
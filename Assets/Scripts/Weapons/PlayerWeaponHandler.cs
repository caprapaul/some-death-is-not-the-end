using UnityEngine;
using UnityEngine.InputSystem;

namespace Weapons
{
    [RequireComponent(typeof(IWeapon), typeof(MouseDirectionCalculator))]
    public class PlayerWeaponHandler : MonoBehaviour, GameInputs.IPlayerActions
    {
        private IWeapon _weapon;
        private GameInputs _gameInputs;
        private MouseDirectionCalculator _directionCalculator;

        private void Start()
        {
            _weapon = GetComponent<IWeapon>();
            _directionCalculator = GetComponent<MouseDirectionCalculator>();
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

        public void OnFire(InputAction.CallbackContext context)
        {
            if (!_weapon.CanFire())
                return;
            
            _weapon.Fire(transform.position, _directionCalculator.Direction);
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            // nothing
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            // nothing
        }
    }
}
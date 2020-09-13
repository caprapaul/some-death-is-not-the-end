using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Events
{
    public class OnAnyKeyPressed : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onAnyKeyPressed;

        private void Update()
        {
            if (Keyboard.current.anyKey.wasPressedThisFrame)
            {
                _onAnyKeyPressed.Invoke();
            }
        }
    }
}
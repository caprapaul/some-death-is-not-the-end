﻿using System;
using Events;
using UnityEngine;
using UnityEngine.Events;

namespace Receivers
{
    public class DamageReceiver : MonoBehaviour
    {
        [SerializeField] 
        private IntEvent _onDamaged;

        public void Damage(int amount)
        {
            Debug.Log("Damaged");
            _onDamaged.Invoke(amount);
        }
    }
}
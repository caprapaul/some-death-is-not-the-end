using Events;
using UnityEngine;

namespace Receivers
{
    public class DamageReceiver : MonoBehaviour
    {
        [SerializeField] 
        private IntEvent _onDamaged;

        public void Damage(int amount)
        {
            _onDamaged.Invoke(amount);
        }
    }
}
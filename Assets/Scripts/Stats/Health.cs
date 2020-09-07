using UnityEngine;
using UnityEngine.Events;

namespace Stats
{
    public class Health : MonoBehaviour
    {
        [SerializeField]
        private int _current;
        [SerializeField]
        private int _maximum;
    
        [SerializeField]
        private UnityEvent _onDamaged;
        [SerializeField] 
        private UnityEvent _onRestored;
        [SerializeField]
        private UnityEvent _onDeath;

        public void Damage(int amount)
        {
            _onDamaged.Invoke();
        
            if (_current - amount <= 0)
            {
                _current = 0;
                _onDeath.Invoke();
            }
            else
            {
                _current -= amount;
            }
        }

        public void Restore(int amount)
        {
            _onRestored.Invoke();
        
            if (_current + amount > _maximum)
            {
                _current = _maximum;
            }
            else
            {
                _current += amount;
            }
        }
    }
}

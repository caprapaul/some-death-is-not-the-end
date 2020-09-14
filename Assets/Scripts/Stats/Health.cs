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

        private bool _isAlive = true;

        public UnityEvent OnDamaged
        {
            get
            {
                return _onDamaged;
            }
        }

        public UnityEvent OnRestored
        {
            get
            {
                return _onRestored;
            }
        }
        
        public UnityEvent OnDeath
        {
            get
            {
                return _onDeath;
            }
        }

        public bool IsAlive
        {
            get
            {
                return _isAlive;
            }
            set
            {
                _isAlive = value;
            }
        }

        public void Damage(int amount)
        {
            if (!IsAlive)
            {
                return;
            }
            
            OnDamaged.Invoke();
        
            if (_current - amount <= 0)
            {
                _current = 0;
                IsAlive = false;
                OnDeath.Invoke();
            }
            else
            {
                _current -= amount;
            }
        }

        public void Restore(int amount)
        {
            OnRestored.Invoke();
        
            if (_current + amount > _maximum)
            {
                _current = _maximum;
            }
            else
            {
                _current += amount;
            }
        }

        public void RestoreAll()
        {
            Restore(_maximum - Mathf.Min(_current, 0));
        }
    }
}

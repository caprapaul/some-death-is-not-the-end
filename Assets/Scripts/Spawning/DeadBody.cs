using UnityEngine;
using UnityEngine.Events;

namespace Spawning
{
    public class DeadBody : MonoBehaviour
    {
        public ParticleSystem OnDeadIlluminatedParticle;

        [SerializeField] private UnityEvent _onPlayerRevive;

        [SerializeField] private UnityEvent _onExpired;

        public bool IsAlive { get; private set; } = true;
        private bool _isParticlePlaying;
        private SpriteRenderer _spriteRenderer;

        public void Start()
        {
            OnDeadIlluminatedParticle.Clear();
            OnDeadIlluminatedParticle.Stop();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetAsDead()
        {
            if (!IsAlive)
                return;
            
            IsAlive = false;
            DeadBodyManager.Instance.RegisterDeadBody(this);
            transform.rotation = Quaternion.Euler(0, 0, 180);
            _spriteRenderer.color = new Color(0.3f, 0.3f, 0.3f);
        }

        public void RemoveItCompletely()
        {
            DeadBodyManager.Instance.RemoveDeadBody(this);
        }

        private void Update()
        {
            if (Player.Current.isAlive && _isParticlePlaying)
            {
                _isParticlePlaying = false;
                OnDeadIlluminatedParticle.Stop();
            }
            else if (!Player.Current.isAlive && !_isParticlePlaying && !IsAlive)
            {
                _isParticlePlaying = true;
                OnDeadIlluminatedParticle.Play();
            }
        }
    }
}
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

        public void Start()
        {
            OnDeadIlluminatedParticle.Clear();
            OnDeadIlluminatedParticle.Stop();
        }

        public void SetAsDead()
        {
            Debug.Log("Im now dead");
            IsAlive = false;
            
            OnDeadIlluminatedParticle.Play();
            DeadBodyManager.Instance.RegisterDeadBody(this);
        }
    }
}
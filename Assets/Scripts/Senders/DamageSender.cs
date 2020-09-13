using Events;
using Receivers;
using UnityEngine;

namespace Senders
{
    public class DamageSender : MonoBehaviour
    {
        [SerializeField] 
        private int _amount;
        
        [SerializeField] 
        private IntEvent _onDamageSend;

        public void Send(Collider2D otherCollider)
        {
            var receiver = otherCollider.GetComponent<DamageReceiver>();

            if (receiver == null)
            {
                return;
            }
            
            receiver.Damage(_amount);
            _onDamageSend.Invoke(_amount);
        }
    }
}
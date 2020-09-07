using Receivers;
using UnityEngine;

namespace Senders
{
    public class DamageSender : MonoBehaviour
    {
        [SerializeField] 
        private int _amount;

        public void Send(Collider2D otherCollider)
        {
            DamageReceiver receiver = otherCollider.GetComponent<DamageReceiver>();

            if (receiver == null)
            {
                return;
            }
            
            receiver.Damage(_amount);
        }
    }
}
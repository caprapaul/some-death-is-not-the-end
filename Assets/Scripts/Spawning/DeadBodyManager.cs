using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawning
{
    public class DeadBodyManager : MonoBehaviour
    {
        public static DeadBodyManager Instance;
        
        public int MaxDeadBodies = 3;
        private Queue<DeadBody> _bodies = new Queue<DeadBody>();

        public void Awake()
        {
            Instance = this;
        }

        public void RegisterDeadBody(DeadBody body)
        {
            if (_bodies.Count >= MaxDeadBodies)
            {
                RemoveDeadBodyOnQueue();
            }
            
            _bodies.Enqueue(body);
        }
        
        private void RemoveDeadBodyOnQueue()
        {
            DeadBody body = _bodies.Dequeue();
            body.gameObject.SetActive(false);
        }

        public void RemoveDeadBody(DeadBody body)
        {
            int hashToRemove = body.GetHashCode();
            _bodies = new Queue<DeadBody>(_bodies.Where(b => b.GetHashCode() != hashToRemove));
        }

        public void ClearAllBodies()
        {
            while (_bodies.Count > 0)
            {
                RemoveDeadBodyOnQueue();
            }
        }
    }
}
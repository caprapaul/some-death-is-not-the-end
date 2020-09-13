using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Spawning
{
    public class DeadBodyManager : MonoBehaviour
    {
        public static DeadBodyManager Instance;
        
        public int MaxDeadBodies = 3;
        public int TotalDeadBodyRetrieved { get; private set; }
        
        private Queue<DeadBody> _bodies = new Queue<DeadBody>();

        public void Awake()
        {
            Instance = this;
        }

        public bool isBodyAvailable => _bodies.Count > 0;

        public void RegisterDeadBody(DeadBody body)
        {
            if (_bodies.Count >= MaxDeadBodies)
            {
                RemoveDeadBodyOnQueue();
            }

            TotalDeadBodyRetrieved++;
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
            
            body.gameObject.SetActive(false);
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
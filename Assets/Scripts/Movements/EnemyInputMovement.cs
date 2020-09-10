using UnityEngine;
using UnityEngine.AI;

namespace Movements
{
    [RequireComponent(typeof(NavMeshAgent), typeof(IMovementHandler))]
    public class EnemyInputMovement: MonoBehaviour
    {
        private NavMeshAgent _agent;
        private IMovementHandler _movementHandler;
        private MovementData _currentMovement;

        private void Start()
        {
            _currentMovement = new MovementData();
            _movementHandler = GetComponent<IMovementHandler>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.updatePosition = false;
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        public void Update()
        {
            _agent.SetDestination(Player.Current.transform.position);
            _currentMovement.Direction = (_agent.nextPosition - transform.position).normalized;
        }
        
        private void FixedUpdate()
        {
            _movementHandler.OnMove(_currentMovement);
        }
    }
}
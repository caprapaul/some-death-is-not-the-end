using System.Data.Common;
using UnityEngine;
using UnityEngine.AI;

namespace Movements
{
    [RequireComponent(typeof(IMovementHandler))]
    public class EnemyInputMovement : MonoBehaviour
    {
        private IMovementHandler _movementHandler;
        private MovementData _currentMovement;
        private NavMeshPath _path;
        private int _mask = -1;

        private void Start()
        {
            _currentMovement = new MovementData();
            _movementHandler = GetComponent<IMovementHandler>();
            _path = new NavMeshPath();
            _mask = 1 << NavMesh.GetAreaFromName("Walkable");
        }

        public void Update()
        {
            NavMesh.SamplePosition(transform.position, out NavMeshHit hitA, 10f, _mask);
            NavMesh.SamplePosition(Player.Current.transform.position, out NavMeshHit hitB, 10f, _mask);

            if (!hitA.position.Equals(Vector3.positiveInfinity) && !hitB.position.Equals(Vector3.positiveInfinity))
            {
                bool canMove = NavMesh.CalculatePath(hitA.position, hitB.position, _mask, _path);
                if (canMove && _path.corners.Length >= 2)
                {
                    Vector2 delta = _path.corners[1] - transform.position;
                    _currentMovement.Direction = delta.normalized;
                }
                else
                    _currentMovement.Direction = Vector2.zero;
            }
            else
            {
                _currentMovement.Direction = Vector2.zero;
            }
        }

        private void FixedUpdate()
        {
            _movementHandler.OnMove(_currentMovement);
        }
    }
}
using UnityEngine;

namespace movement
{
    public class MovePositionDirect : MonoBehaviour, IMovePosition
    {
        private Vector3 _targetPosition;
        private IMoveVelocity _moveVelocity;

        private void Start()
        {
            _moveVelocity = GetComponent<IMoveVelocity>();
        }

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        private void Update()
        {
            Vector3 direction = (_targetPosition - transform.position).normalized;
            if (Vector3.Distance(_targetPosition, transform.position) < 1f) direction = Vector3.zero;
            _moveVelocity.SetVelocity( direction);
        }
    }
}
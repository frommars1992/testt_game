using UnityEngine;

namespace movement
{
    public class MovePositionTowards : MonoBehaviour, IMovePosition
    {
        private Vector3 _targetPosition;
        private IMoveVelocity _moveVelocity;

        public void SetTargetPosition(Vector3 targetPosition)
        {
            _moveVelocity = GetComponent<IMoveVelocity>();
            _targetPosition = targetPosition;
            Vector3 direction = (_targetPosition - transform.position).normalized;
            _moveVelocity.SetVelocity( direction);
        }
    }

    public interface IMovePosition
    {
        void SetTargetPosition(Vector3 targetPosition);
    }
}
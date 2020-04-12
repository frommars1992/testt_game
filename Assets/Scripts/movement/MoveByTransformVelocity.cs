using strange.extensions.mediation.impl;
using UnityEngine;

namespace movement
{
    public class MoveByTransformVelocity : View, IMoveVelocity
    {
        [SerializeField] private float _speed;
        private Vector3 _velocityVector;

        private void Update()
        {
            transform.position += _velocityVector *(_speed * Time.deltaTime);
        }

        public void SetVelocity(Vector3 velocityVector)
        {
            _velocityVector = velocityVector;
        }
    }
}
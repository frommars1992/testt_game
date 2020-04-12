using strange.extensions.mediation.impl;
using UnityEngine;

namespace movement
{
    public class PlayerMovement : View
    {
        [Inject] public SignalPlayerChangeMovement jSignalPlayerChangeMovement { get; set; }
        private float moveX = 0f;
        private float moveY = 0f;
        private IMoveVelocity _moveVelocity;

        private Vector3 _movementVector;

        public Vector3 MovementVector
        {
            get => _movementVector;
            set
            {
                if (_movementVector == value)
                {
                    return;
                }

                transform.rotation = Quaternion.LookRotation(value);
                if (value == Vector3.zero)
                {
                    jSignalPlayerChangeMovement.Dispatch(false);
                    _movementVector = value;
                    return;
                }

                jSignalPlayerChangeMovement.Dispatch(true);
                _movementVector = value;
            }
        }

        protected override void Start()
        {
            base.Start();
            _moveVelocity = GetComponent<IMoveVelocity>();
        }

        void FixedUpdate()
        {
            moveX = 0;
            moveY = 0;

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) moveY = +1;
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) moveY = -1;
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) moveX = -1;
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) moveX = +1;

            MovementVector = new Vector3(moveX, 0, moveY).normalized;

            _moveVelocity.SetVelocity(MovementVector);
        }
    }
}
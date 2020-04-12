using System.Collections;
using strange.extensions.mediation.impl;
using TestGame.Signals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace movement
{
    public class EnemyRandomMovement : View
    {
        [Inject] public EnemySettings jEnemySettings { get; set; }
        private Vector3 _targetPosition;
        private Vector3 _startPosition;
        private Vector2 _limit;
        private MovePositionDirect _movePositionDirect;

        private bool _needToMove;

        protected  override void Awake()
        {
            base.Awake();
            _movePositionDirect = GetComponent<MovePositionDirect>();
            _startPosition = transform.position;
        }

        protected override void Start()
        {
            base.Start();
            _limit = jEnemySettings.MoveLimiter;
            SetRandomPosition();    
        }

        private void SetRandomPosition()
        {
            _needToMove = transform;
            _targetPosition = _startPosition + GetRandomDir();
        }

        private void Update()
        {
            _movePositionDirect.SetTargetPosition(_targetPosition);
            var moveDirection = transform.position - _targetPosition;
            if (_needToMove && moveDirection.sqrMagnitude < 1f)
            {
                StartCoroutine(SetNewPosition());
            }
        }

        private IEnumerator SetNewPosition()
        {
            _needToMove = false;
            yield return new WaitForSeconds(1f);
            SetRandomPosition();
        }

        private Vector3 GetRandomDir() 
        {
            return new Vector3( Random.Range(-_limit.x,_limit.x),0 , Random.Range(-_limit.y,_limit.y));
        }
    }
}
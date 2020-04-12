using System.Collections;
using strange.extensions.mediation.impl;
using TestGame.Signals.game_logic;
using UnityEngine;

namespace gameLogic
{
    public class PlayerMediator : Mediator
    {
        [Inject] public PlayerView jPlayerView { get; set; }
        [Inject] public IEnemyManager jIEnemyManager { get; set; }
        [Inject] public SignalPlayerChangeMovement jSignalPlayerChangeMovement { get; set; }
        public IWeapon jWeapon { get; set; }

        private bool _isAttacking;
        private Coroutine _attackRoutine;

        public override void OnRegister()
        {
            jSignalPlayerChangeMovement.AddListener(OnPlayerStopMovement);
            jWeapon = GetComponentInChildren<IWeapon>();
        }

        public void OnPlayerStopMovement(bool isMove)
        {
            if (!isMove)
            {
                _isAttacking = true;
                StartAttack();
                var nearestEnemy = jIEnemyManager.GetNearest(transform);

                if (nearestEnemy != null)
                {
                    transform.LookAt(nearestEnemy.GameObject.transform);
                }
            }

            if (isMove)
            {
                StopAttack();
                _isAttacking = false;
            }
        }
        
        private void StartAttack()
        {
            _attackRoutine = StartCoroutine(AttackRoutine());
        }

        private void StopAttack()
        {
            if (_attackRoutine != null)
            {
                StopCoroutine(_attackRoutine);
            }
        }

        private void ShootEnemy()
        {
            var nearestEnemy = jIEnemyManager.GetNearest(jPlayerView.transform);

            if (nearestEnemy != null)
            {
                jPlayerView.transform.LookAt(nearestEnemy.GameObject.transform);
                jWeapon.Shoot(nearestEnemy.GameObject.transform.position);
            }
        }

        private IEnumerator AttackRoutine()
        {
            while (_isAttacking)
            {
                yield return new WaitForSeconds(jWeapon.Cooldown);
                ShootEnemy();
            }
        }
    }
}
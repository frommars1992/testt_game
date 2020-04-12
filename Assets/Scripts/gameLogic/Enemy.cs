using strange.extensions.mediation.impl;
using TestGame.Signals;
using TestGame.Signals.game_logic;
using UnityEngine;

namespace gameLogic
{
    public class Enemy : Mediator, IEnemy
    {
        private int _health = 3;
        [Inject] public EnemySettings jEnemySettings { get; set; }
        [Inject] public SignalEnemyDie jSignalEnemyDie { get; set; }
        [Inject] public SignalEnemyHit jSignalEnemyHit { get; set; }
        [Inject] public IEnemyManager jEnemyManager { get; set; }
        [Inject] public EnemyView jEnemyView { get; set; }
        public GameObject GameObject => jEnemyView.gameObject;

        private int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health == 0)
                {
                    _health = 0;
                    Death();
                }
            }
        }

        [PostConstruct]
        public void PostConstruct()
        {
            jEnemyManager.Register(this);
            _health = jEnemySettings.Health;
        }

        private void Death()
        {
            jSignalEnemyDie.Dispatch(this);
            jEnemyView.DestroyIt();
        }

        public void Hit(int damage)
        {
            Health -= damage;
            jEnemyView.Hit();
            jSignalEnemyHit.Dispatch();
        }
    }
}
using System.Collections.Generic;
using gameLogic;
using UnityEngine;

namespace TestGame.Signals.game_logic
{
    public class EnemyManager : IEnemyManager
    {
        [Inject] public SignalEnemyDie jSignalEnemyDie { get; set; }
        private List<IEnemy> enemyList = new List<IEnemy>();


        [PostConstruct]
        public void PostConstruct()
        {
            jSignalEnemyDie.AddListener(enemy =>
            {
                if (enemyList.Contains(enemy))
                {
                    enemyList.Remove(enemy);
                }
            });
        }
        
        public void Register(IEnemy enemyToRegister)
        {
            if (!enemyList.Contains(enemyToRegister))
            {
                enemyList.Add(enemyToRegister);
            }
        }

        public IEnemy GetNearest(Transform targetTransform)
        {
            IEnemy nearest = null;
            float minimalDistance = float.MaxValue;

            for (int i = 0; i < enemyList.Count; i++)
            {
                var targetDirection = targetTransform.position - enemyList[i].GameObject.transform.position;
                var sqrMagnitude = targetDirection.sqrMagnitude;
                if (sqrMagnitude < minimalDistance)
                {
                    minimalDistance = sqrMagnitude;
                    nearest = enemyList[i];
                }
            }

            return nearest;
        }
    }

    public interface IEnemyManager
    {
        void Register(IEnemy enemyToRegister);
        IEnemy GetNearest(Transform targetTransform);
    }
}
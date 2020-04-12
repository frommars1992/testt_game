using strange.extensions.mediation.impl;
using UnityEngine;

namespace gameLogic
{
    public class EnemyFabric : Mediator
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _spawnOrigin;
        [SerializeField] private Vector2 _spawnRange;
        [SerializeField] private int _enemyAmount;
    
        void Start()
        {
            for (int i = 0; i < _enemyAmount; i++)
            {
                Instantiate(_enemyPrefab,_spawnOrigin.position + GetSpawnBias(),Quaternion.identity);
            }
        }

        private Vector3 GetSpawnBias()
        {
            return new Vector3(Random.Range( -_spawnRange.x,_spawnRange.x), 0,Random.Range(-_spawnRange.y,_spawnRange.y));
        }
    }
}

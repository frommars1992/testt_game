using UnityEngine;

namespace TestGame.Signals
{
    [CreateAssetMenu(fileName = "EnemySettings", menuName = "EnemySettings", order = 0)]
    public class EnemySettings : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _moveLimiter;
        [SerializeField] private int _health;
        

        public Vector2 MoveLimiter => _moveLimiter;

        public float Speed => _speed;

        public int Health => _health;
    }
}
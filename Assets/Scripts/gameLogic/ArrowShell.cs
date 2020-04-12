using movement;
using UnityEngine;

namespace gameLogic
{
    public class ArrowShell : MonoBehaviour, IShell
    {
        private int _damage;
        private IMovePosition _movePositionTowards;

        public void Init(int damage, Vector3 target)
        {
            DestroyAfterDelay();
            _movePositionTowards = GetComponent<IMovePosition>();
            transform.LookAt(target);
            _movePositionTowards.SetTargetPosition(target);
            _damage = damage;
        }

        private void OnTriggerEnter(Collider other)
        {
            var enemyHit = other.GetComponent<IEnemy>();
            enemyHit?.Hit(_damage);
            Destroy(gameObject);
        }

        private void DestroyAfterDelay()
        {
            Destroy(gameObject, 10f);
        }
    }
}
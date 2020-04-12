using UnityEngine;

namespace gameLogic
{
    public interface IEnemy
    {
        GameObject GameObject { get; }
        void Hit(int damage);
    }
}
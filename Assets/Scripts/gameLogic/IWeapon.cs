using UnityEngine;

namespace gameLogic
{
    public interface IWeapon
    {
        float Cooldown { get; }
        int Damage { get; }

        void Shoot(Vector3 target);
    }
}
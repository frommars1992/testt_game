using strange.extensions.mediation.impl;
using UnityEngine;

namespace gameLogic
{
    public class Bow : Mediator, IWeapon
    {
        [Inject] public BowView jBowView { get; set; }
        public float Cooldown => 1f;
        public int Damage => 1;

        public void Shoot(Vector3 target)
        {
            jBowView.LaunchArrow(Damage, target);
        }
    }
}
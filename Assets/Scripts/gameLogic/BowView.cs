using strange.extensions.mediation.impl;
using UnityEngine;

namespace gameLogic
{
    public class BowView : View
    {
        [SerializeField] private GameObject _shell;
        [SerializeField] private Transform _launchPoint;

        public void LaunchArrow(int arrowDamage, Vector3 target)
        {
            var shell = Instantiate(_shell, _launchPoint.position, Quaternion.identity).GetComponent<IShell>();
            shell.Init(arrowDamage, target);
        }
    }

    public interface IShell
    {
        void Init(int damage, Vector3 target);
    }
}
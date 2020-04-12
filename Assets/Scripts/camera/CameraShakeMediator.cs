using strange.extensions.mediation.impl;
using UnityEngine;

namespace camera
{
    public class CameraShakeMediator : Mediator
    {
        [Inject] public SignalEnemyHit jSignalEnemyHit { get; set; }
        [Inject] public CameraShakeView jCameraShakeView { get; set; }

        private Coroutine _shakeRoutine;

        public override void OnRegister()
        {
            jSignalEnemyHit.AddListener(Shake);
        }

        void Shake()
        {
            if (_shakeRoutine != null)
            {
                StopCoroutine(_shakeRoutine);
            }

            _shakeRoutine = StartCoroutine(jCameraShakeView.Shake(0.16f, .1f));
        }
    }
}
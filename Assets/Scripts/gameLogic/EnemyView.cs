using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace gameLogic
{
    public class EnemyView : View
    {
        public void DestroyIt()
        {
            Destroy(gameObject);
        }

        public void Hit()
        {
            transform.DOScale(transform.localScale * 0.7f, 0.1f).OnComplete(() =>
            {
                transform.DOScale(Vector3.one * 0.7f, 0.1f);
            });
        }
    }
}
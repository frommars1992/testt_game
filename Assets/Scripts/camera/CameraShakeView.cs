using System.Collections;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace camera
{
    public class CameraShakeView : View
    {
        public IEnumerator Shake(float duration, float magnitude)
        {
            Vector3 orignalPosition = transform.position;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                float x = Random.Range(-1f, 1f) * magnitude;
                float z = Random.Range(-1f, 1f) * magnitude;
                transform.position += new Vector3(x, 0, z);
                elapsed += Time.deltaTime;
                yield return 0;
            }

            transform.position = orignalPosition;
        }
    }
}
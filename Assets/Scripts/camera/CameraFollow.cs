using UnityEngine;

namespace camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float smoothing = 10;
        [SerializeField] private Vector3 offset;

        private void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothing * Time.deltaTime);
        }
    }
}
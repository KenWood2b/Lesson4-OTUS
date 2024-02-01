using UnityEngine;

namespace Sample
{
    public sealed class CameraFollower : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;

        [SerializeField]
        private Vector3 offset;

        [SerializeField]
        private float smoothTime;

        private void LateUpdate()
        {
            //Реализовать преследование камеры за персонажем с указанным offset и плавностью перемещения smoothTime.
            //Для плавности использовать Math.SmoothDamp() / Vector3.SmoothDamp();
            Vector3 desiredPosition = character.transform.position + offset;
            Vector3 velocity = Vector3.zero;
            transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);
        }
    }
}
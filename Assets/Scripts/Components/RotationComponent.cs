using UnityEngine;

namespace Sample
{
    public sealed class RotationComponent : MonoBehaviour
    {
        public float RotationSpeed
        {
            get => this.rotationSpeed;
            set => this.rotationSpeed = value;
        }

        public Vector3 RotationDirection
        {
            get => this.rotationDirection;
            set => this.rotationDirection = value;
        }

        [SerializeField]
        private float rotationSpeed;

        [SerializeField]
        private Vector3 rotationDirection;

        private void Update()
        {
            //TODO: Реализовать покадровый поворот через transform с помощью методов
            //Quaternion.RotateTowards, Quaternion.LookRotation и
            //параметров rotationSpeed, rotationDirection и Time.fixedDeltaTime;
            //если направление перемещения ноль, то поворот не происходит
            if (rotationDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(rotationDirection);
                Quaternion currentRotation = transform.rotation;
                Quaternion newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
                transform.rotation = newRotation;

            }
        }
    }
}
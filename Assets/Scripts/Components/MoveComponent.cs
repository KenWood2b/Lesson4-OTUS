using UnityEngine;

namespace Sample
{
    public sealed class MoveComponent : MonoBehaviour
    {
        public float MoveSpeed
        {
            get => this.moveSpeed;
            set => this.moveSpeed = value;
        }

        public Vector3 MoveDirection
        {
            get => this.moveDirection;
            set => this.moveDirection = value;
        }

        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private Vector3 moveDirection;
        
        private void FixedUpdate()
        {
            //TODO: Реализовать покадровое перемещение через transform с помощью
            //параметров moveSpeed, moveDirection и Time.fixedDeltaTime;
            transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
using UnityEngine;

namespace Sample
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;
        
        private void Update()
        {
            //TODO: Реализовать перемещение и поворот в нужную сторону с помощью нажатия WASD / Стрелочек на клавиатуре
            float moveSpeed = 5f;

            float horizontalInput = Input.GetAxis("Horizontal"); 
            float verticalInput = Input.GetAxis("Vertical"); 

            Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

            if (moveDirection != Vector3.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(moveDirection);
                character.transform.rotation = rotation;

                character.transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            }
        }
    }
}
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
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
            character.transform.Translate(movement * Time.deltaTime);

            if (movement != Vector3.zero)
            {
                character.transform.rotation = Quaternion.LookRotation(movement);
            }
        }
    }
}
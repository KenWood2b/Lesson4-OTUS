using UnityEngine;

namespace Sample
{
    public sealed class Сharacter : MonoBehaviour
    {

        [SerializeField]
        private MoveComponent moveComponent;
        [SerializeField]
        private RotationComponent rotationComponent;
        [SerializeField]
        private HealthComponent healthComponent;
        bool isAlive = true;
        private void FixedUpdate()
        {

            this.UpdateLifeState();
        }
        
        private void UpdateRotation()
        {
            rotationComponent.RotationDirection = moveComponent.MoveDirection;
        }
        private void UpdateLifeState()
        {
            //TODO:
            //Реализовать условие перемещения и поворота:
            //перемещаться и вращаться можно если здоровье больше нуля, иначе перемещение и вращение не происходят 
            //Реализовать механику включения: если здоровье равно нулю, то игровой объект должен быть выключен на сцене,
            //если здоровье есть — то включен
            //

            isAlive = healthComponent.Health > 0;
            moveComponent.enabled = isAlive;
            rotationComponent.enabled = isAlive;
            
        }


    }
}
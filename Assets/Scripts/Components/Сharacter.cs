using UnityEngine;

namespace Sample
{
    public sealed class Сharacter : MonoBehaviour
    {
        private void FixedUpdate()
        {

            this.UpdateLifeState();
        }

        private void UpdateLifeState()
        {
            //TODO:
            //Реализовать условие перемещения и поворота:
            //перемещаться и вращаться можно если здоровье больше нуля, иначе перемещение и вращение не происходят 
            //Реализовать механику включения: если здоровье равно нулю, то игровой объект должен быть выключен на сцене,
            //если здоровье есть — то включен
            //
            
            gameObject.SetActive(false);
            

        }
    }
}
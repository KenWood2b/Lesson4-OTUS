using System;
using UnityEngine;


namespace Sample
{
    public sealed class HealthComponent : MonoBehaviour
    {
        public int MaxHealth
        {
            get => this.maxHealth;
            set => this.maxHealth = value;
        }
        
        public int Health
        {
            get => this.health;
            set => this.health = value;
        }

        [SerializeField]
        private int maxHealth;

        [SerializeField]
        private int health;

        public void TakeDamage(int damage)
        {
            //TODO: Реализовать получение урона для параметра health, минимальное значение здоровья равно нулю

            health -= damage;
            if(health <= 0)
            {
                health = 0;
            }
        }

        public void RestoreHitPoints(int range)
        {
            //TODO: Реализовать восстановление здоровья для параметра health, макс. значение здоровья равно maxHealth.
            health += range;

            if(health > maxHealth)
            {
                health = maxHealth;
            }

        }
    }
}
using System;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float startingHealth = 100f;
        
        private float _health;
        private bool _dead;
        [SerializeField] private bool canBeKilled = true;

        private void Start()
        {
            _health = startingHealth;
            _dead = false;
        }

        public float GetHealth()
        {
            return _health;
        }
        

        public void IncreaseHealth(float val)
        {
            if (_dead) return;
            _health += val;
            if (_health > startingHealth) _health = startingHealth;
        }

        public bool IsDead()
        {
            return _dead;
        }

        public void TakeDamage(float damage)
        {
            if(!canBeKilled) return; 
            if (_health <= damage)
            {
                _health = 0;
                _dead = true;
                GameEvents.Instance.PlayerDeath();
                return;
            }
            _health -= damage;
        }
    }
}

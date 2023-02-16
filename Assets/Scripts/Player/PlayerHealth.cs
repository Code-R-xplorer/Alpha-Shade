using System;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
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

        public void DecreaseHealth(float val)
        {
            if(!canBeKilled) return; 
            if (_health <= val)
            {
                _health = 0;
                _dead = true;
                GameEvents.Instance.PlayerDeath();
                return;
            }
            _health -= val;
        }

        public void IncreaseHealth(float val)
        {
            if (_dead) return;
            _health += val;
        }

        public bool IsDead()
        {
            return _dead;
        }

    }
}

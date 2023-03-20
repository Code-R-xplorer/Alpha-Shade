using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ability_System
{
    public class Ability : MonoBehaviour
    {
        public string abilityName;
        public int uses;
        public float cooldown;
        
        [HideInInspector]
        public bool selected;
        [HideInInspector]
        public bool inCooldown;
        [HideInInspector]
        public float cooldownTime;

        public virtual void Initialization(AbilityManager abilityManager)
        {
            
        }

        private void Update()
        {
            if (inCooldown)
            {
                cooldownTime -= Time.deltaTime;
                if (cooldownTime <= 0f) inCooldown = false;
            }
        }

        public virtual void Action()
        {
            if (uses <= 0 || inCooldown) return;
            cooldownTime = cooldown;
            inCooldown = true;
        }

        // protected IEnumerator 
    }
}
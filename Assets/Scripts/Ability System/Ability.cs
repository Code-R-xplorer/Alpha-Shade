using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

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

        protected bool used;

        public virtual void Initialization(AbilityManager abilityManager)
        {
            
        }

        private void Update()
        {
            if (inCooldown)
            {
                cooldownTime -= Time.deltaTime;
                if (cooldownTime <= 0f)
                {
                    inCooldown = false;
                    used = false;
                }
            }
        }

        public virtual void Action()
        {
            if (uses <= 0 || inCooldown)
            {
                AudioManager.Instance.PlayOneShot("abilityNotReady");
                return;
            }
            cooldownTime = cooldown;
        }

        // protected IEnumerator 
    }
}
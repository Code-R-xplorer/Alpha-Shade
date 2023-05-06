using Managers;
using Player;
using UnityEngine;
using Utilities;

namespace Ability_System
{
    public class HealthInjection : Ability
    {
        private PlayerHealth playerHealth;
        [SerializeField] private float healValue;
        public override void Initialization(AbilityManager abilityManager)
        {
            base.Initialization(abilityManager);
            playerHealth = abilityManager.player.GetComponent<PlayerHealth>();
        }

        public override void Action()
        {
            base.Action();
            if (uses <= 0 || inCooldown)
            {
                if(used) return;
            }
            used = true;
            inCooldown = true;
            AudioManager.Instance.PlayOneShot("healthUse");
            playerHealth.IncreaseHealth(healValue);
        }
    }
}
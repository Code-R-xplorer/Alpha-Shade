using Player;
using UnityEngine;

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
            playerHealth.IncreaseHealth(healValue);
        }
    }
}
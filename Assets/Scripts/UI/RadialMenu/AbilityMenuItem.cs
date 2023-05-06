using Ability_System;
using Managers;
using UnityEngine;

namespace UI.RadialMenu
{
    public class AbilityMenuItem : ItemBase
    {
        public Ability ability;
        public AbilityManager abilityManager;

        private string heading;
        private string body;
        
        
        public void Initialization(Ability a, AbilityManager m)
        {
            ability = a;
            abilityManager = m;
        }

        public override void OnHover()
        {
            base.OnHover();
            body = "";
            heading = ability.selected ? $"Current Ability: {ability.abilityName}" : $"Ability: {ability.abilityName}";
            body = $"Uses: {ability.uses} \n" +
                   $"Cooldown: {ability.cooldown} \n" +
                   $"Cooldown Info:\n";
            body += ability.inCooldown ? $"Cooldown Time Remaining: {ability.cooldownTime}" : $"Ready To Use";
            infoDisplayTab.UpdateText(heading, body);
        }

        public override void OnPerformAction()
        {
            base.OnPerformAction();
            abilityManager.SelectAbility(ability.abilityName);
        }
    }
}
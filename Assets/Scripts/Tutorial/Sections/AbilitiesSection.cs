using System;
using Ability_System;
using UnityEngine;

namespace Tutorial.Sections
{
    public class AbilitiesSection : TutorialSection
    {
        [Header("Modal Triggers")] 
        [SerializeField] private GameObject modalOne;
        [SerializeField] private GameObject modalTwo;

        [Header("Extras")] 
        [SerializeField] private AbilityManager abilityManager;
        
        public override void StartSection()
        {
            base.StartSection();
            modalOne.SetActive(true);
        }

        private void Update()
        {
            if (!sectionStarted) return;
            if(abilityManager.selectedAbility == null) return;
            if(abilityManager.selectedAbility.name == "Shock Dart" &&
               abilityManager.selectedAbility.inCooldown && !modalTwo.activeSelf) modalTwo.SetActive(true);
        }
    }
}
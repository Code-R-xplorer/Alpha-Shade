using System;
using Ability_System;
using Gun_System;
using Interactables;
using UnityEngine;

namespace Tutorial.Sections
{
    public class WeaponsSection : TutorialSection
    {
        [Header("Modal Triggers")] 
        [SerializeField] private GameObject modalOne;
        [SerializeField] private GameObject modalTwo;
        [SerializeField] private GameObject modalThree;
        [SerializeField] private GameObject modalFour;
        [SerializeField] private GameObject modalFive;

        [Header("Extras")]
        [SerializeField] private Crate weaponCrate;
        [SerializeField] private Crate ammoCrate;
        [SerializeField] private GameObject rifle;
        [SerializeField] private GameObject guardOne;
        [SerializeField] private GameObject guardTwo;
        [SerializeField] private AbilityManager abilityManager;
        
        public override void StartSection()
        {
            base.StartSection();
            modalOne.SetActive(true);
        }

        private void Update()
        {
            if(!sectionStarted) return;
            if(weaponCrate.IsOpen() && !modalTwo.activeSelf) modalTwo.SetActive(true);
            if (!modalTwo.activeSelf) return;
            if(rifle.activeSelf && !modalThree.activeSelf) modalThree.SetActive(true);
            if (!modalThree.activeSelf) return;
            if(ammoCrate.IsOpen() && !modalFour.activeSelf) modalFour.SetActive(true);
            if (!modalFour.activeSelf) return;
            if (guardOne == null && guardTwo == null && !modalFive.activeSelf) modalFive.SetActive(true);
            if (!modalFive.activeSelf) return;
            if(abilityManager.selectedAbility == null) return;
            if(abilityManager.selectedAbility.name == "Health Injection" &&
               abilityManager.selectedAbility.inCooldown) TutorialManager.Instance.EnableDialog(2);

        }
    }
}
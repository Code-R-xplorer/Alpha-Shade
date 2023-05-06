using System;
using Interactables;
using Managers;
using UnityEngine;

namespace Tutorial.Sections
{
    public class DoorsSection : TutorialSection
    {
        [Header("Modal Triggers")] 
        [SerializeField] private GameObject modalOne;
        [SerializeField] private GameObject modalTwo;
        [SerializeField] private GameObject modalThree;
        [SerializeField] private GameObject modalFour;

        [Header("Extras")] 
        [SerializeField] private GameObject keycard;
        [SerializeField] private Door door;
        
        public override void StartSection()
        {
            base.StartSection();
            InputManager.Instance.OnToggleMenu += RadialMenuTriggered;
            modalOne.SetActive(true);
        }

        private void Update()
        {
            if(!sectionStarted) return;
            if(keycard == null && !modalTwo.activeSelf) modalTwo.SetActive(true);
            if(door.HasKeyCard && !modalFour.activeSelf) modalFour.SetActive(true);
        }

        private void RadialMenuTriggered(bool canceled)
        {
            if(canceled) modalThree.SetActive(true);
        }
    }
}
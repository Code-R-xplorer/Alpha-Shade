using System;
using Managers;
using UnityEngine;

namespace Tutorial.Sections
{
    public class IDSection : TutorialSection
    {
        [Header("Modal Triggers")] 
        [SerializeField] private GameObject modalOne;
        [SerializeField] private GameObject modalTwo;
        [SerializeField] private GameObject modalThree;

        [Header("Extras")] 
        [SerializeField] private GameObject idCard;
        [SerializeField] private IDManager idManager;
        
        public override void StartSection()
        {
            base.StartSection();
            modalOne.SetActive(true);
        }

        private void Update()
        {
            if(!sectionStarted) return;
            if(idCard == null && !modalTwo.activeSelf) modalTwo.SetActive(true);
            if(idManager.CheckCorrectIDLevel(AccessLevel.Medium) && !modalThree.activeSelf) modalThree.SetActive(true);
        }
    }
}
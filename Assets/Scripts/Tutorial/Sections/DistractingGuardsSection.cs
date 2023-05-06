using System;
using Guards;
using UnityEngine;
using UnityEngine.Serialization;

namespace Tutorial.Sections
{
    public class DistractingGuardsSection : TutorialSection
    {
        [Header("Modal Triggers")] 
        [SerializeField] private GameObject modalOne;
        [SerializeField] private GameObject modalTwo;

        [Header("Extras")] 
        [SerializeField] private StationaryGuard stationaryGuard;
        public override void StartSection()
        {
            base.StartSection();
            modalOne.SetActive(true);
        }

        private void Update()
        {
            if(!sectionStarted) return;
            if(stationaryGuard.Investigating() && !modalTwo.activeSelf) modalTwo.SetActive(true);
        }
    }
}
using UnityEngine;

namespace Tutorial.Sections
{
    public class GuardsOverviewSection : TutorialSection
    {
        [Header("Modal Triggers")] 
        [SerializeField] private GameObject modalOne;
        
        public override void StartSection()
        {
            base.StartSection();
            modalOne.SetActive(true);
        }
    }
}
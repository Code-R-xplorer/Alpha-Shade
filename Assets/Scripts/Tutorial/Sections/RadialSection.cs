using UnityEngine;

namespace Tutorial.Sections
{
    public class RadialSection : TutorialSection
    {
        [Header("Modal Trigger")]
        [SerializeField] private GameObject modal;
        public override void StartSection()
        {
            base.StartSection();
            modal.SetActive(true);
            
        }
    }
}
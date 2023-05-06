using UnityEngine;

namespace Tutorial.Sections
{
    public class MovementSection : TutorialSection
    {
        [Header("Modal Triggers")]
        [SerializeField] private GameObject movementTwo;
        [SerializeField] private GameObject movementThree;
        
        public int totalBarrels;
        
        public void BarrelCollected()
        {
            totalBarrels--;
            TutorialManager.Instance.UpdateObjectiveText($"Barrels Remaining: {totalBarrels}");
            if(!movementTwo.activeSelf) movementTwo.SetActive(true);
            if(movementTwo.activeSelf && totalBarrels <= 1) movementThree.SetActive(true);
            if (totalBarrels <= 0)
            {
                TutorialManager.Instance.UpdateObjectiveText("Go to the next training area!");
                endDoor.UnlockDoor();
                nextSectionDoor.UnlockDoor();
            }
        }
    }
}
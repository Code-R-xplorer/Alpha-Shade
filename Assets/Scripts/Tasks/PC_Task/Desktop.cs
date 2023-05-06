using UnityEngine;

namespace Tasks.PC_Task
{
    public class Desktop : MonoBehaviour
    {
        [SerializeField] private GameObject corruptFile;
        [SerializeField] private int objectiveID;
        
        
        public void ShowCorruptFile()
        {
            corruptFile.SetActive(true);
            transform.parent.GetComponent<PC>().CompleteObjective(objectiveID, false);
        }
    }
}
using System.Collections.Generic;
using UnityEngine;

namespace Tasks.PC_Task
{
    public class Email : MonoBehaviour
    {
        [SerializeField] private int objectiveID;
        [SerializeField] private int objectiveEmailID = -1;
        [SerializeField] private List<GameObject> emails;

        private int _prevEmail;

        public void ShowEmail(int emailID)
        {
            emails[_prevEmail].SetActive(false);
            emails[emailID].SetActive(true);
            _prevEmail = emailID;
            if (objectiveEmailID == emailID)
            {
                transform.parent.GetComponent<PC>().CompleteObjective(objectiveID);
            }
        }
    }
}
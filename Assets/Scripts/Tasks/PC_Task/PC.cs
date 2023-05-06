using Managers;
using UI;
using UnityEngine;
using Utilities;

namespace Tasks.PC_Task
{
    public class PC : MonoBehaviour
    {
        [SerializeField] private int pcID;
        [SerializeField] private GameObject loginScreen;
        [SerializeField] private GameObject desktop;
        [SerializeField] private GameObject fileExplorer;
        [SerializeField] private GameObject email;

        public void Login()
        {
            loginScreen.SetActive(false);
            desktop.SetActive(true);
        }

        public void ShowDesktop()
        {
            desktop.SetActive(true);
            fileExplorer.SetActive(false);
            email.SetActive(false);
        }
        
        public void ShowFileExplorer()
        {
            desktop.SetActive(false);
            fileExplorer.SetActive(true);
            email.SetActive(false);
        }
        
        public void ShowEmail()
        {
            desktop.SetActive(false);
            fileExplorer.SetActive(false);
            email.SetActive(true);
        }

        public void CompleteObjective(int objectiveID, bool hideScreen)
        {
            ObjectivesManager.Instance.ObjectiveComplete(objectiveID);
            if (!hideScreen) return;
            UIManager.Instance.HideComputerScreen(pcID);
        }
        
    }
}
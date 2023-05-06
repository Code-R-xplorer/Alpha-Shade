using System;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class LevelSelect : MonoBehaviour
    {
        [SerializeField] private GameObject tutorialPanel;
        [SerializeField] private GameObject hyperionPanel;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void PlayButtonClick(string levelName)
        {
            // AudioManager.Instance.PlayOneShot("uiClick");
            SceneManager.LoadScene(levelName);
        }

        public void SwitchPanelButton(string panel)
        {
            // AudioManager.Instance.PlayOneShot("uiClick");
            switch (panel)
            {
                case "Tutorial":
                    tutorialPanel.SetActive(true);
                    hyperionPanel.SetActive(false);
                    break;
                case "Hyperion":
                    tutorialPanel.SetActive(false);
                    hyperionPanel.SetActive(true);
                    break;
            }
        }

        public void MainMenuButton()
        {
            // AudioManager.Instance.PlayOneShot("uiClick");
            SceneManager.LoadScene("Main_Menu");
        }
    }
}
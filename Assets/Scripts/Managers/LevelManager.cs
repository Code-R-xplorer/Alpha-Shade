using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        private void Awake()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void MainMenuButtonClicked()
        {
            // AudioManager.Instance.PlayOneShot("uiClick");
            SceneManager.LoadScene("Main_Menu");
        }

        public void RetryButtonClicked()
        {
            // AudioManager.Instance.PlayOneShot("uiClick");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void StartGameButtonClicked()
        {
            // AudioManager.Instance.PlayOneShot("uiClick");
            SceneManager.LoadScene(AppManager.Instance.tutorialComplete ? "Level_Select" : "Tutorial");
        }

        public void QuitGameButtonClicked()
        {
            // AudioManager.Instance.PlayOneShot("uiClick");
            Application.Quit();
        }
        
        // public void ButtonHover()
        // {
        //     AudioManager.Instance.PlayOneShot("uiHover");
        // }
    }
}

using System;
using Managers;
using UnityEngine;

namespace UI
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private GameObject pauseVolume;

        public void ResumeButtonClick()
        {
            GameManager.Instance.TogglePause();
        }

        public void SkipTutorialButtonClick()
        {
            AppManager.Instance.tutorialComplete = true;
        }

        private void OnEnable()
        {
            if(pauseVolume == null) return;
            pauseVolume.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void OnDisable()
        {
            if(pauseVolume == null) return;
            pauseVolume.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
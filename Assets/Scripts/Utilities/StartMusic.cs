using System;
using Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class StartMusic : MonoBehaviour
    {
        private void Start()
        {
            if(SceneManager.GetActiveScene().name == "Main_Menu") AudioManager.Instance.Play("mainMenuTheme",transform);
            if(SceneManager.GetActiveScene().name == "Tutorial") AudioManager.Instance.Play("tutorialTheme",transform);
            if(SceneManager.GetActiveScene().name == "Level_Select") AudioManager.Instance.Play("levelSelectTheme",transform);
            if(SceneManager.GetActiveScene().name == "Tech_Company") AudioManager.Instance.Play("techLevelTheme",transform);
        }
    }
}
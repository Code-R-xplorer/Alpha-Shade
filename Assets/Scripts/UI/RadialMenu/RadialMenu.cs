using System;
using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class RadialMenu : MonoBehaviour
    {

        private bool isOpen;

        public GameObject[] menus;

        private int menuIndex;
        private void Start()
        {
            InputManager.Instance.OnToggleMenu += ShowMainMenu;
            foreach (var menu in menus)
            {
                menu.GetComponent<Menu>().radialMenu = this;
                menu.SetActive(false);
            }
        }
        
        private void ShowMainMenu(bool canceled)
        {
            isOpen = !canceled;
            InputManager.Instance.CursorLock(!isOpen);
            if (isOpen)
            {
                Time.timeScale = 0;
                menuIndex = 0;
                menus[0].SetActive(isOpen);
            }
            else
            {
                Time.timeScale = 1;
                foreach (var menu in menus)
                {
                    menu.SetActive(false);
                }
            }
        }

        public void SwitchMenu(int newMenu)
        {
            menus[menuIndex].SetActive(false);
            menuIndex = newMenu;
            menus[menuIndex].SetActive(true);
            
        }
    }
}
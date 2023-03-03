using System;
using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class RadialMenu : MonoBehaviour
    {

        private bool isOpen;

        public Menu[] menus;

        private int menuIndex;
        private void Start()
        {
            InputManager.Instance.OnToggleMenu += ShowMainMenu;
            foreach (var menu in menus)
            {
                menu.radialMenu = this;
                menu.ToggleMenu(false);
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
                menus[0].ToggleMenu(isOpen);
            }
            else
            {
                Time.timeScale = 1;
                foreach (var menu in menus)
                {
                    menu.ToggleMenu(false);
                }
            }
        }

        public void SwitchMenu(int newMenu)
        {
            menus[menuIndex].ToggleMenu(false);
            menuIndex = newMenu;
            menus[menuIndex].ToggleMenu(true);
            
        }
    }
}
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

        [SerializeField] private int weaponIndex, idIndex;

        private IDManager idManager;

        [SerializeField] private GameObject idMenuItem, weaponMenuItem;
        
        [SerializeField] private GameObject infoTab;
        public InfoDisplayTab infoDisplayTab;
        private void Start()
        {
            InputManager.Instance.OnToggleMenu += ShowMainMenu;
            idManager = IDManager.Instance;
            foreach (var menu in menus)
            {
                menu.radialMenu = this;
                menu.ToggleMenu(false);
            }
            infoTab.SetActive(false);
            infoDisplayTab = infoTab.GetComponent<InfoDisplayTab>();
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
                menus[menuIndex].PerformAction();
                Time.timeScale = 1;
                foreach (var menu in menus)
                {
                    menu.ToggleMenu(false);
                }
                infoTab.SetActive(false);
            }
        }

        public void ToggleInfoTab(bool show)
        {
            infoTab.SetActive(show);
            menus[0].ToggleMenu(!show);
        }

        public void ChangeSubMenu(int newMenu)
        {
            if (menuIndex != 0)
            {
                menus[menuIndex].ToggleMenu(false);
            }

            menuIndex = newMenu;
            menus[menuIndex].ToggleMenu(true);
        }
    }
}
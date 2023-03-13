using System;
using System.Linq;
using Gun_System;
using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class RadialMenu : MonoBehaviour
    {

        private bool isOpen;

        public Menu[] menus;

        private int menuIndex;

        public int weaponIndex, idIndex;

        public IDManager IDManager { get; private set; }

        [SerializeField] private GameObject idMenuItemPrefab, weaponMenuItemPrefab;
        
        [SerializeField] private GameObject infoTab;
        public InfoDisplayTab infoDisplayTab;
        private void Start()
        {
            InputManager.Instance.OnToggleMenu += ShowMainMenu;
            IDManager = IDManager.Instance;
            foreach (var menu in menus)
            {
                menu.radialMenu = this;
                menu.ToggleMenu(false);
            }
            infoTab.SetActive(false);
            infoDisplayTab = infoTab.GetComponent<InfoDisplayTab>();
        }

        public void AddMenuItem(int idNumber, string idName, string idAccessLevel)
        {
            var idMenuItem = Instantiate(idMenuItemPrefab, menus[idIndex].transform, false);
            var menuItem = idMenuItem.GetComponent<IDMenuItem>();
            menuItem.Initialize(idNumber, idName, idAccessLevel);
            // menus[idIndex].ToggleMenu(true);
            menus[idIndex].menuItems.Add(menuItem);
            menus[idIndex].UpdateItemUIs();
            // menus[idIndex].ToggleMenu(false);
        }

        public void AddMenuItem(string gunName,int gunIndex, Gun gun)
        {
            var gunMenuItem = Instantiate(weaponMenuItemPrefab, menus[weaponIndex].transform, false);
            var menuItem = gunMenuItem.GetComponent<WeaponMenuItem>();
            menuItem.Initialize(gunName, gunIndex, gun);
            menus[weaponIndex].menuItems.Add(menuItem);
            menus[weaponIndex].UpdateItemUIs();
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
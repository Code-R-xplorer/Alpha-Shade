using System;
using System.Linq;
using Ability_System;
using Gun_System;
using Managers;
using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class RadialMenu : MonoBehaviour
    {

        private bool isOpen;

        public Menu[] menus;

        private int menuIndex;

        public int infoIndex, weaponIndex, idIndex, abilityIndex, keyIndex;

        public IDManager IDManager { get; private set; }

        [SerializeField] private GameObject idMenuItemPrefab, weaponMenuItemPrefab, abilityMenuItemPrefab, keyMenuItemPrefab;
        
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
            menus[idIndex].menuItems.Add(menuItem);
            menus[idIndex].UpdateItemUIs();
        }

        public void AddMenuItem(string gunName,int gunIndex, Gun gun)
        {
            var gunMenuItem = Instantiate(weaponMenuItemPrefab, menus[weaponIndex].transform, false);
            var menuItem = gunMenuItem.GetComponent<WeaponMenuItem>();
            menuItem.Initialize(gunName, gunIndex, gun);
            menus[weaponIndex].menuItems.Add(menuItem);
            menus[weaponIndex].UpdateItemUIs();
        }

        public void AddMenuItem(Ability ability, AbilityManager abilityManager)
        {
            var abilityMenuItem = Instantiate(abilityMenuItemPrefab, menus[abilityIndex].transform, false);
            var menuItem = abilityMenuItem.GetComponent<AbilityMenuItem>();
            menuItem.Initialization(ability, abilityManager);
            menus[abilityIndex].menuItems.Add(menuItem);
            menus[abilityIndex].UpdateItemUIs();
        }

        public void AddMenuItem(int keyID)
        {
            var keyMenuItem = Instantiate(keyMenuItemPrefab, menus[keyIndex].transform, false);
            var menuItem = keyMenuItem.GetComponent<KeyMenuItem>();
            menuItem.Initialize(keyID);
            menus[keyIndex].menuItems.Add(menuItem);
            menus[keyIndex].UpdateItemUIs();
        }

        public void RemoveMenuItem(string menuName, int menuItemID)
        {
            int menuID = 0;
            if (menuName == "Weapon") menuID = weaponIndex;
            if (menuName == "ID") menuID = idIndex;
            if (menuName == "Ability") menuID = abilityIndex;
            if (menuName == "Key") menuID = keyIndex;
            var menuItem = menus[menuID].menuItems[menuItemID];
            Destroy(menuItem.gameObject);
            menus[menuID].menuItems.Remove(menuItem);
            menus[menuID].UpdateItemUIs();
        }

        private void ShowMainMenu(bool canceled)
        {
            if (UIManager.Instance.ComputerScreenShown || GameManager.Instance.Paused) return;
            isOpen = !canceled;
            InputManager.Instance.CursorLock(!isOpen);
            if (isOpen)
            {
                UIManager.Instance.ToggleObjectives(true);
                Time.timeScale = 0;
                menuIndex = 0;
                menus[0].ToggleMenu(isOpen);
                GameManager.Instance.canPause = false;
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
                UIManager.Instance.ToggleObjectives(false);
                GameManager.Instance.canPause = true;
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
using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class Menu : MonoBehaviour
    {

        public bool IsOpen { get; private set; }
        private GameObject menu;

        private Vector2 screenCenter;

        public int selection;
        private int prevSelection;
        private float angleNumber;
        public List<ItemBase> menuItems;

        private ItemBase radialMenuItem;
        private ItemBase prevRadialMenuItem;

        public RadialMenu radialMenu;

        private bool reselect;
        
        [SerializeField] private float threshold;

        private float _sectionRadius = 155;

        private bool _isMain;

        private float currentAngleOffset;

        public List<float> angleOffsets;

        // Start is called before the first frame update
        private void Awake()
        {
            menu = gameObject;
            if (menu.name == "MainMenu")
            {
                _isMain = true;
            }
        }

        void Start()
        {
            if (menuItems.Count == 0) return;
            screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            angleNumber = 360f / menuItems.Count;

            foreach (var item in menuItems)
            {
                item.Init(radialMenu, radialMenu.infoDisplayTab);
            }

            currentAngleOffset = angleOffsets[menuItems.Count];

        }

        public void UpdateItemUIs()
        {
            screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            angleNumber = 360f / menuItems.Count;
            for (int i = 0; i < menuItems.Count; i++)
            {
                var item = menuItems[i];
                item.UpdateItemUI(menuItems.Count, i);
                item.Init(radialMenu, radialMenu.infoDisplayTab);
            }
            currentAngleOffset = angleOffsets[menuItems.Count];
        }

        // Update is called once per frame
        void Update()
        {
            if(!IsOpen) return;
            Vector2 deflection = InputManager.Instance.MousePos - screenCenter;
            if (deflection.magnitude > threshold && deflection.magnitude < threshold + _sectionRadius)
            {
                // Debug.Log(Mathf.Atan2(deflection.y, deflection.x) * Mathf.Rad2Deg);
                float angle = Mathf.Atan2(deflection.y, deflection.x) * Mathf.Rad2Deg + currentAngleOffset;
                angle = (angle + 360) % 360;
                // Debug.Log(angle);
                selection = (int)(angle / angleNumber);
                if (selection >= menuItems.Count) selection = 0;
                if (prevSelection >= menuItems.Count) prevSelection = 0;
                if (selection < 0) selection = 0;
                if (prevSelection < 0) prevSelection = 0;
                Hover();
                if (reselect)
                {
                    radialMenuItem.Select();
                    reselect = false;
                }
                if (selection != prevSelection)
                {
                    prevRadialMenuItem = menuItems[prevSelection];
                    prevRadialMenuItem.Deselect();
                    prevSelection = selection;

                    radialMenuItem = menuItems[selection];
                    radialMenuItem.Select();
                }

                if (!_isMain)
                {
                    radialMenu.ToggleInfoTab(true);
                }
                
            }
            else if ((deflection.magnitude < threshold || deflection.magnitude > threshold + _sectionRadius) && (prevRadialMenuItem != null || radialMenuItem != null))
            {
                prevRadialMenuItem.Deselect();
                radialMenuItem.Deselect();
                reselect = true;
                radialMenu.ToggleInfoTab(false);
            }
            if (deflection.magnitude < threshold && _isMain)
            {
                radialMenu.ChangeSubMenu(0);
                radialMenu.ToggleInfoTab(false);
            }
            
        }

        public void ToggleMenu(bool open)
        {
            IsOpen = open;
            menu.SetActive(IsOpen);
        }

        private void Hover()
        {
            if(menuItems.Count == 0) return;
            menuItems[selection].OnHover();
        }

        public void PerformAction()
        {
            if (reselect || menuItems.Count == 0) return;
            menuItems[selection].OnPerformAction();
        }
    }
}

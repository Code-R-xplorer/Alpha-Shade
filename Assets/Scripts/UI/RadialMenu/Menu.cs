using System;
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
        [SerializeField] private ItemBase[] menuItems;

        private ItemBase radialMenuItem;
        private ItemBase prevRadialMenuItem;

        public RadialMenu radialMenu;

        private bool reselect;
        
        [SerializeField] private float threshold;

        private float _sectionRadius = 155;

        private bool _isMain;
        
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
            // InputManager.Instance.OnClick += Click;
            screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            angleNumber = 360f / menuItems.Length;
            // menu.SetActive(false);

            foreach (var item in menuItems)
            {
                item.Init(radialMenu, radialMenu.infoDisplayTab);
            }
            

        }

        // Update is called once per frame
        void Update()
        {
            if(!IsOpen) return;
            Vector2 deflection = InputManager.Instance.MousePos - screenCenter;
            if (deflection.magnitude > threshold && deflection.magnitude < threshold + _sectionRadius)
            {
                float angle = Mathf.Atan2(deflection.y, deflection.x) * Mathf.Rad2Deg;
                angle = (angle + 360) % 360;
                selection = (int)(angle / angleNumber);
                Hover();
                if (selection >= menuItems.Length) selection = 0;
                if (prevSelection >= menuItems.Length) prevSelection = 0;
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
            menuItems[selection].OnHover();
        }

        public void PerformAction()
        {
            if (reselect) return;
            menuItems[selection].OnPerformAction();
        }
    }
}

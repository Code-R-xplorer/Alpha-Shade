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

        [SerializeField] private bool outer;

        [SerializeField] private float innerThreshold;
        [SerializeField] private float outerThreshold;

        private float threshold;
        // Start is called before the first frame update
        private void Awake()
        {
            menu = gameObject;
        }

        void Start()
        {
            InputManager.Instance.OnClick += Click;
            screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            angleNumber = 360f / menuItems.Length;
            // menu.SetActive(false);
            if (outer)
            {
                threshold = outerThreshold;
            }
            else
            {
                threshold = innerThreshold;
            }

            foreach (var item in menuItems)
            {
                item.Init(radialMenu);
            }

        }

        // Update is called once per frame
        void Update()
        {
            // if (!isOpen) return;
            Vector2 deflection = InputManager.Instance.MousePos - screenCenter;
            if (deflection.magnitude > threshold)
            {
                float angle = Mathf.Atan2(deflection.y, deflection.x) * Mathf.Rad2Deg;
                angle = (angle + 360) % 360;
                selection = (int)(angle / angleNumber);
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
            }
            else if (deflection.magnitude < threshold && (prevRadialMenuItem != null || radialMenuItem != null))
            {
                prevRadialMenuItem.Deselect();
                radialMenuItem.Deselect();
                reselect = true;
            }
        }

        public void ToggleMenu(bool open)
        {
            Debug.Log(gameObject.name + ": " + open);
            IsOpen = open;
            menu.SetActive(IsOpen);
        }

        private void Click()
        {
            if(!IsOpen) return;
            menuItems[selection].OnClick();
        }
    }
}

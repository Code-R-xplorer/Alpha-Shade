using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class Menu : MonoBehaviour
    {

        // private bool isOpen;
        // private GameObject menu;

        private Vector2 screenCenter;

        public int selection;
        private int prevSelection;
        private float angleNumber;
        [SerializeField] private ItemBase[] radialMenuItems;

        private ItemBase radialMenuItem;
        private ItemBase prevRadialMenuItem;

        public RadialMenu radialMenu;
        // Start is called before the first frame update
        void Start()
        {
            InputManager.Instance.OnClick += Click;
            screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            // menu = gameObject;
            angleNumber = 360f / radialMenuItems.Length;
            // menu.SetActive(false);

            foreach (var item in radialMenuItems)
            {
                item.Init(radialMenu);
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            // if (!isOpen) return;
            Vector2 deflection = InputManager.Instance.MousePos - screenCenter;
            float angle = Mathf.Atan2(deflection.y, deflection.x) * Mathf.Rad2Deg;
            angle = (angle + 360) % 360;
            selection = (int)(angle / angleNumber);
            if (selection != prevSelection)
            {
                prevRadialMenuItem = radialMenuItems[prevSelection].GetComponent<ItemBase>();
                prevRadialMenuItem.Deselect();
                prevSelection = selection;

                radialMenuItem = radialMenuItems[selection].GetComponent<ItemBase>();
                radialMenuItem.Select();
            }
        }

        private void Click()
        {
            // if(!isOpen) return;
            radialMenuItems[selection].OnClick();
        }
    }
}

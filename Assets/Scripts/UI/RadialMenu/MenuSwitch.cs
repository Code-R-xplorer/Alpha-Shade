using UnityEngine;

namespace UI.RadialMenu
{
    public class MenuSwitch : ItemBase
    {
        [SerializeField] private int menuID;
        public override void OnClick()
        {
            base.OnClick();
            radialMenu.SwitchMenu(menuID);
        }
    }
}
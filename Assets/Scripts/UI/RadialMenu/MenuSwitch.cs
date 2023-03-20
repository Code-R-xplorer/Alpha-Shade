using UnityEngine;

namespace UI.RadialMenu
{
    public class MenuSwitch : ItemBase
    {
        [SerializeField] private int menuID;
        public override void OnHover()
        {
            base.OnHover();
            if (menuID == -1) return;
            radialMenu.ChangeSubMenu(menuID);
        }
    }
}
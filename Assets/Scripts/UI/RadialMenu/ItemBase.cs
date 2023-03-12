using UnityEngine;
using UnityEngine.UI;

namespace UI.RadialMenu
{
    public class ItemBase : MonoBehaviour
    {
        public Color hoverColor;
        public Color baseColor;
        public Image background;

        protected RadialMenu radialMenu;
        protected InfoDisplayTab infoDisplayTab;

        public void Init(RadialMenu menu, InfoDisplayTab displayTab)
        {
            radialMenu = menu;
            infoDisplayTab = displayTab;
        }

        protected virtual void Start()
        {
            background.color = baseColor;
        }

        public void Select()
        {
            background.color = hoverColor;
        }

        public void Deselect()
        {
            background.color = baseColor;
        }

        public virtual void OnHover()
        {
            
        }

        public virtual void OnPerformAction()
        {
            
        }
        
    }
}
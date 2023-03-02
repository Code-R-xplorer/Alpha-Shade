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

        public void Init(RadialMenu menu)
        {
            radialMenu = menu;
        }

        private void Start()
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

        public virtual void OnClick()
        {
            
        }
    }
}
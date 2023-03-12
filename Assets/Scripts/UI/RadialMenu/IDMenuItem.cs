using UnityEngine;

namespace UI.RadialMenu
{
    public class IDMenuItem : ItemBase
    {
        public int id;
        public string idName;
        public string idAccessLevel;

        private string heading;
        private string body;

        protected override void Start()
        {
            base.Start();
            heading = "ID Card";
            body = $"Name: {idName} \n Access Level: {idAccessLevel}";
        }

        public override void OnPerformAction()
        {
            base.OnPerformAction();
            radialMenu.IDManager.SelectID(id);
        }

        public override void OnHover()
        {
            base.OnHover();
            infoDisplayTab.UpdateText(heading, body);
        }
    }
}
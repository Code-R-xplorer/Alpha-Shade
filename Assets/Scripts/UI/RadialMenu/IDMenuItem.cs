using System.ComponentModel;
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

        public void Inititlize(int idNumber, string nameID, string accessLevel)
        {
            id = idNumber;
            idName = nameID;
            idAccessLevel = accessLevel;
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
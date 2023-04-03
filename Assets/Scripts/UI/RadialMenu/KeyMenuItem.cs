using System;
using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class KeyMenuItem : ItemBase
    {
        public int id;

        private bool keyUsed;
        
        private string heading;
        private string body;
        
        public void Initialize(int keyID)
        {
            id = keyID;
            heading = $"Key Card #{id}";
            body = "Key Cards can be used as a base to open any door that requires a key card to open";
        }

        private void Update()
        {
            heading = KeyCardManager.Instance.CheckKeySelected(id) ? $"Current Key Card #{id}" : $"Key Card #{id}";
        }

        public override void OnPerformAction()
        {
            base.OnPerformAction();
            KeyCardManager.Instance.SelectKeyCard(id);
        }

        public override void OnHover()
        {
            base.OnHover();
            if (!keyUsed)
            {
                if (KeyCardManager.Instance.CheckKeyUsed(id))
                {
                    body =
                        $"Key Card has already been used for the {KeyCardManager.Instance.GetKeyCardDoorName(id)}" +
                        " door\nYou will need to select another card to use as a base";
                    keyUsed = true;
                }
            }
            infoDisplayTab.UpdateText(heading, body);
        }
        
    }
}
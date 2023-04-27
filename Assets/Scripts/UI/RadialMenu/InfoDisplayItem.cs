using System;
using TMPro;
using UnityEngine;
using Utilities;

namespace UI.RadialMenu
{
    public class InfoDisplayItem : ItemBase
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GameObject parentObject;
        [SerializeField] private int index = -1;

        private IDisplayText _displayText;

        protected override void Start()
        {
            base.Start();
            if (parentObject == null) return;
            _displayText = index != -1 ? parentObject.GetComponentsInChildren<IDisplayText>()[index] : parentObject.GetComponent<IDisplayText>();
        }

        public override void OnHover()
        {
            base.OnHover();
            radialMenu.ToggleInfoTab(false);
            // infoDisplayTab.UpdateText("", "");
        }

        private void OnEnable()
        {
            if (_displayText == null) return;
            text.text = _displayText.GetDisplayText();
        }
    }
}
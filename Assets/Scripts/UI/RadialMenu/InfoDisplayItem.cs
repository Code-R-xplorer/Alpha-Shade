using TMPro;
using UnityEngine;

namespace UI.RadialMenu
{
    public class InfoDisplayItem : ItemBase
    {
        [SerializeField] private TextMeshProUGUI text;

        public void UpdateText(string newText)
        {
            text.text = newText;
        }
    }
}
using TMPro;
using UnityEngine;

namespace UI.RadialMenu
{
    public class InfoDisplayTab : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI headingText;
        [SerializeField] private TextMeshProUGUI bodyText;

        
        public void UpdateText(string heading, string body)
        {
            headingText.text = heading;
            bodyText.text = body;
        }
    }
}
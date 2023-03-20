using TMPro;
using UnityEngine;
using Utilities;

namespace UI.Pocket_Watch
{
    public class ID : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI idName;
        [SerializeField] private TextMeshProUGUI accessLevel;

        public void CreateID(string idNameString, string accessLevelString)
        {
            idName.text = "Name: " + idNameString;
            accessLevel.text = "Access Level: " + accessLevelString;
        }
        
    }
}
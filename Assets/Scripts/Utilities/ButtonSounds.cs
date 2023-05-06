using Managers;
using UnityEngine;

namespace Utilities
{
    public class ButtonSounds : MonoBehaviour
    {
        public void ButtonHover()
        {
            AudioManager.Instance.PlayOneShot("uiHover");
        }

        public void ButtonClick()
        {
            AudioManager.Instance.PlayOneShot("uiClick");
        }
    }
}
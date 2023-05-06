using System;
using Managers;
using UnityEngine;

namespace Utilities
{
    public class StartMusic : MonoBehaviour
    {
        private void Start()
        {
            AudioManager.Instance.Play("mainMenuTheme",transform);
        }
    }
}
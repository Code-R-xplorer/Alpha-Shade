using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OptionsMenu : MonoBehaviour
    {
        [SerializeField] private Slider master, sfx, music;
        
        private void Start()
        {
            master.value = AppManager.Instance.masterSlider;
            sfx.value = AppManager.Instance.sfxSlider;
            music.value = AppManager.Instance.musicSlider;
        }
        
        public void SetMasterVol(float value)
        {
            AppManager.Instance.SetMasterVol(value);
        }
        public void SetSFXVol(float value)
        {
            AppManager.Instance.SetSFXVol(value);
        }
        public void SetMusicVol(float value)
        {
            AppManager.Instance.SetMusicVol(value);
        }
    }
}
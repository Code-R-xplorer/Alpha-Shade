using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

namespace Managers
{
    public class AppManager : MonoBehaviour
    {
        public static AppManager Instance { get; private set; }

        public bool tutorialComplete;
        
        public AudioMixer audioMixer;
        public float masterVol, sfxVol, musicVol;
        public float masterSlider = 1, sfxSlider = 1, musicSlider = 1;
        
        private void Awake()
        {
            // Check if there is already an AudioManager instance and if it's different from this instance.
            if (Instance != null && Instance != this)
            {
                // Destroy this game object if there's already an AudioManager instance.
                Destroy(gameObject);
                return;
            }

            // Set the AudioManager instance to this instance.
            Instance = this;
            // Make sure the AudioManager instance is not destroyed when loading a new scene.
            DontDestroyOnLoad(gameObject);
        }
        
        public void SetMasterVol(float value)
        {
            masterSlider = value;
            masterVol = Mathf.Log10(value) * 20;
            audioMixer.SetFloat("MasterVol", masterVol);
        }
        public void SetSFXVol(float value)
        {
            sfxSlider = value;
            sfxVol = Mathf.Log10(value) * 20;
            audioMixer.SetFloat("SFXVol", sfxVol);
        }
        public void SetMusicVol(float value)
        {
            musicSlider = value;
            musicVol = Mathf.Log10(value) * 20;
            audioMixer.SetFloat("MusicVol", musicVol);
        }
    }
}
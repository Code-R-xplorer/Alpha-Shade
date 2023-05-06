using System;
using Player;
using UI;
using UnityEngine;
using Utilities;
using Motion = Player.Motion;

namespace Managers
{
    public class GameManager : MonoBehaviour, IDisplayText
    {
        public static GameManager Instance;

        public bool tutorial;

        [Header("Floors")] 
        [SerializeField] private GameObject level0;
        [SerializeField] private GameObject level1;
        [SerializeField] private GameObject level2;
        private GameObject _player;

        private bool _recordTimePlayed = true;
        private float _currentPlayTime;

        public bool Paused { get; private set; }
        public bool canPause = true;
        
        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += PlayerDeath;
            GameEvents.Instance.OnGameComplete += GameComplete;
            InputManager.Instance.OnPause += TogglePause;
            _player = GameObject.FindWithTag(Tags.Player);

            if (!tutorial)
            {
                level1.SetActive(false);
                level2.SetActive(false);
            }
            
            _currentPlayTime = 0f;
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            if (_recordTimePlayed)
            {
                _currentPlayTime = Time.time;
            }
        }

        private void PlayerDeath()
        {
            TogglePlayer(false);
            InputManager.Instance.CursorLock(false);
            _recordTimePlayed = false;
        }

        public void TogglePlayer(bool enable)
        {
            _player.GetComponent<Motion>().enabled = enable;
            _player.GetComponent<Look>().enabled = enable;
        }

        private void GameComplete()
        {
            TogglePlayer(false);
            InputManager.Instance.CursorLock(false);
            _recordTimePlayed = false;
        }
        
        public void LoadFloor(int floor)
        {
            switch (floor)
            {
                case 0:
                    level0.SetActive(true);
                    level1.SetActive(false);
                    level2.SetActive(false);
                    break;
                case 1:
                    level0.SetActive(false);
                    level1.SetActive(true);
                    level2.SetActive(false);
                    break;
                case 2:
                    level0.SetActive(false);
                    level1.SetActive(false);
                    level2.SetActive(true);
                    break;
            }
        }

        public string GetDisplayText()
        {
            return $"Time Played: {TimeSpan.FromSeconds(_currentPlayTime).Minutes}m :" +
                   $" {TimeSpan.FromSeconds(_currentPlayTime).Seconds}s";
        }

        public float GetPlayTime()
        {
            return _currentPlayTime;
        }

        public void TogglePause()
        {
            if (!canPause) return;
            Paused = !Paused;
            UIManager.Instance.TogglePauseMenu(Paused);
            Time.timeScale = Paused ? 0f : 1f;
        }
    }
}
using System;
using Player;
using UnityEngine;
using Motion = Player.Motion;

namespace Utilities
{
    public class GameManager : MonoBehaviour, IDisplayText
    {
        public static GameManager Instance;

        [Header("Floors")] 
        [SerializeField] private GameObject level0;
        [SerializeField] private GameObject level1;
        [SerializeField] private GameObject level2;
        private GameObject _player;

        private bool _recordTimePlayed = true;
        private float _currentPlayTime;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += PlayerDeath;
            GameEvents.Instance.OnGameComplete += GameComplete;
            _player = GameObject.FindWithTag(Tags.Player);

            level1.SetActive(false);
            level2.SetActive(false);
            _currentPlayTime = 0f;
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
    }
}
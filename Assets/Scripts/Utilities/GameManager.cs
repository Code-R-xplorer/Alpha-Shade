using Player;
using UnityEngine;

namespace Utilities
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Floors")] 
        [SerializeField] private GameObject level0;
        [SerializeField] private GameObject level1;
        [SerializeField] private GameObject level2;
        private GameObject player;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += PlayerDeath;
            player = GameObject.FindWithTag(Tags.Player);

            level1.SetActive(false);
            level2.SetActive(false);
        }

        private void PlayerDeath()
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerLook>().enabled = false;
            InputManager.Instance.CursorLock(false);
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
        
    }
}
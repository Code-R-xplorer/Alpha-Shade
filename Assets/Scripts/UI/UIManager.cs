using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        [SerializeField] private GameObject hud;

        [SerializeField] private GameObject gameOver;

        [SerializeField] private GameObject gameComplete;

        [SerializeField] private TextMeshProUGUI objectives;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += DisplayGameOver;
            GameEvents.Instance.OnGameComplete += DisplayGameComplete;
        }

        public void UpdateObjectives(List<Tuple<bool, string>> objectiveList)
        {
            string objectivesString = "";
            foreach (var objective in objectiveList)
            {
                if (objective.Item1)
                {
                    objectivesString += $"<color=\"green\"><s>{objective.Item2}</s></color>";
                }
                else
                {
                    objectivesString += objective.Item2;
                }
                objectivesString += "\n";
            }

            objectives.text = objectivesString;
        }

        private void DisplayGameComplete()
        {
            hud.SetActive(false);
            gameComplete.SetActive(true);
        }
        
        private void DisplayGameOver()
        {
            hud.SetActive(false);
            gameOver.SetActive(true);
        }

        
    }
}

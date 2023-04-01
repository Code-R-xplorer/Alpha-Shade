using System;
using System.Collections;
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

        [SerializeField] private Animator objectivesAnimator;

        private static readonly int FadeIn = Animator.StringToHash("ObjectivesFadeIn");
        private static readonly int FadeOut = Animator.StringToHash("ObjectivesFadeOut");

        // private Color objectiveTextColor;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += DisplayGameOver;
            GameEvents.Instance.OnGameComplete += DisplayGameComplete;
            // objectiveTextColor = objectivesText[0].color;
        }

        public void UpdateCurrentObjective(List<Tuple<bool, string>> objectiveList)
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

        public void ToggleObjectives(bool show)
        {
            if (show)
            {
                objectivesAnimator.Play(FadeIn, -1, 0.0f);
            }
            else
            {
                StartCoroutine(DelayFade());
            }
        }

        private IEnumerator DelayFade()
        {
            yield return new WaitForSeconds(2);
            objectivesAnimator.Play(FadeOut, -1, 0.0f);
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

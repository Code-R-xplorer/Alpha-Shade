using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using Player;
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

        [SerializeField] private GameObject pauseMenu;

        [SerializeField] private TextMeshProUGUI objectives;

        [SerializeField] private Animator objectivesAnimator;

        [SerializeField] private List<GameObject> computerScreens;

        [SerializeField] private GameObject crosshair;

        [SerializeField] private TextMeshProUGUI timeText;
        
        [SerializeField] private GameObject pauseVolume;

        public bool ComputerScreenShown { get; private set; }

        private static readonly int FadeIn = Animator.StringToHash("ObjectivesFadeIn");
        private static readonly int FadeOut = Animator.StringToHash("ObjectivesFadeOut");

        private bool _objectivesShown;
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

        public void UpdateObjectivesText(List<Tuple<bool, string>> objectiveList)
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
            StartCoroutine(QuickShowObjectives());

        }

        public void ToggleObjectives(bool show)
        {
            if (GameManager.Instance.tutorial) return;
            _objectivesShown = show;
            if (show)
            {
                Debug.Log("Shown");
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

        private IEnumerator QuickShowObjectives()
        {
            if (GameManager.Instance.tutorial || _objectivesShown) yield break;
            ToggleObjectives(true);
            yield return new WaitForSeconds(2f);
            ToggleObjectives(false);
        }

        private void DisplayGameComplete()
        {
            hud.SetActive(false);
            float time = GameManager.Instance.GetPlayTime();
            timeText.text = $"Time: {TimeSpan.FromSeconds(time).Minutes}m :" +
                            $" {TimeSpan.FromSeconds(time).Seconds}s";
            pauseVolume.SetActive(true);
            gameComplete.SetActive(true);
        }
        
        private void DisplayGameOver()
        {
            hud.SetActive(false);
            pauseVolume.SetActive(true);
            gameOver.SetActive(true);
        }

        public void ShowComputerScreen(int id)
        {
            ToggleCrosshair(false);
            ToggleObjectives(true);
            computerScreens[id].SetActive(true);
            ComputerScreenShown = true;
            GameManager.Instance.TogglePlayer(false);
            StateManager.Instance.SetState(StateManager.States.Normal);
            InputManager.Instance.CursorLock(false);
        }

        private IEnumerator HideComputer(int id)
        {
            yield return new WaitForSeconds(3f);
            GameManager.Instance.TogglePlayer(true);
            ComputerScreenShown = false;
            computerScreens[id].SetActive(false);
            ToggleCrosshair(true);
            ToggleObjectives(false);
            InputManager.Instance.CursorLock(true);
        }

        public void HideComputerScreen(int id)
        {
            StartCoroutine(HideComputer(id));
        }

        private void ToggleCrosshair(bool enable)
        {
            crosshair.SetActive(enable);
        }

        public void ToggleHUD(bool show)
        {
            hud.SetActive(show);
        }

        public void TogglePauseMenu(bool show)
        {
            pauseMenu.SetActive(show);
            hud.SetActive(!show);
        }

        
    }
}

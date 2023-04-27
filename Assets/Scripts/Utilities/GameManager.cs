using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UI;
using UI.Pocket_Watch;
using UnityEngine;
using Motion = Player.Motion;

namespace Utilities
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [Header("Objectives")]
        [SerializeField] private Objective[] objectives;
        [SerializeField] private bool allObjectivesComplete;

        [Header("Floors")] 
        [SerializeField] private GameObject level0;
        [SerializeField] private GameObject level1;
        [SerializeField] private GameObject level2;
        private GameObject player;
        private ObjectivesScreen objectivesScreen;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += PlayerDeath;
            // UIManager.Instance.UpdateCurrentObjective(GetCurrentObjective());
            player = GameObject.FindWithTag(Tags.Player);
            // objectivesScreen = player.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(2)
            //     .GetComponent<ObjectivesScreen>();
            UIManager.Instance.UpdateCurrentObjective(GetObjectives());
            
            level1.SetActive(false);
            level2.SetActive(false);
        }

        public void ObjectiveComplete(int objectiveID)
        {
            foreach (var objective in objectives)
            {
                if (objective.objectiveID == objectiveID)
                {
                    if (objective.finalObjective)
                    {
                        if (!CheckCompleteFinal())
                        {
                            return;
                        }
                    }
                    objective.completed = true;
                }
            }
            // UIManager.Instance.UpdateCurrentObjective(GetCurrentObjective());
            UIManager.Instance.UpdateCurrentObjective(GetObjectives());
            allObjectivesComplete = CheckAllComplete();
        }

        private bool CheckAllComplete()
        {
            bool allComplete = true;
            foreach (var objective in objectives)
            {
                if (!objective.completed)
                {
                    allComplete = false;
                    break;
                }
            }

            return allComplete;
        }
        private bool CheckCompleteFinal()
        {
            bool allCompleteFinal = true;
            foreach (var objective in objectives)
            {
                if (!objective.completed && !objective.finalObjective)
                {
                    allCompleteFinal = false;
                    break;
                }
            }

            return allCompleteFinal;
        }
        

        public void CheckComplete()
        {
            if (allObjectivesComplete)
            {
                player.GetComponent<Motion>().enabled = false;
                player.GetComponent<Look>().enabled = false;
                InputManager.Instance.CursorLock(false);
                GameEvents.Instance.GameComplete();
                // Time.timeScale = 0f;
            }
        }

        private void PlayerDeath()
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerLook>().enabled = false;
            InputManager.Instance.CursorLock(false);
            // Time.timeScale = 0f;
        }

        public List<Tuple<bool, string>> GetObjectives()
        {
            List<Tuple<bool, string>> allObjectives = new List<Tuple<bool, string>>();
            // Tuple<bool, string>[] allObjectives = new Tuple<bool, string>[objectives.Length];

            foreach (var objective in objectives)
            {
                allObjectives.Add(new Tuple<bool, string>(objective.completed, objective.objectiveName));
            }

            return allObjectives;
        }

        public string GetCurrentObjective()
        {
            foreach (var objective in objectives)
            {
                if (!objective.completed)
                {
                    return objective.objectiveName;
                }
            }

            return "";
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

    [System.Serializable]
    public class Objective
    {
        public int objectiveID;
        public string objectiveName;
        public bool completed;
        public bool finalObjective;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Player;
using UI;
using UI.Pocket_Watch;
using UnityEngine;

namespace Utilities
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private Objective[] objectives;
        [SerializeField] private bool allObjectivesComplete;
        [SerializeField] private GameObject AI;
        private GameObject player;
        private ObjectivesScreen objectivesScreen;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += PlayerDeath;
            UIManager.Instance.UpdateCurrentObjective(GetCurrentObjective());
            player = GameObject.FindWithTag(Tags.Player).transform.root.gameObject;
            objectivesScreen = player.transform.GetChild(0).GetChild(2).GetChild(2).GetChild(2)
                .GetComponent<ObjectivesScreen>();
            objectivesScreen.UpdateObjectivesScreen(GetObjectives());
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
            UIManager.Instance.UpdateCurrentObjective(GetCurrentObjective());
            objectivesScreen.UpdateObjectivesScreen(GetObjectives());
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
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<PlayerLook>().enabled = false;
                AI.SetActive(false);
                InputManager.Instance.CursorLock(false);
                GameEvents.Instance.GameComplete();
                // Time.timeScale = 0f;
            }
        }

        private void PlayerDeath()
        {
            AI.SetActive(false);
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
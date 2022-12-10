using System;
using UnityEngine;

namespace Utilities
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] private Objective[] objectives;
        [SerializeField] private bool allObjectivesComplete;
        [SerializeField] private GameObject AI;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            GameEvents.Instance.OnPlayerDeath += PlayerDeath;
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
                GameEvents.Instance.GameComplete();
                Time.timeScale = 0f;
            }
        }

        private void PlayerDeath()
        {
            AI.SetActive(false);
            Time.timeScale = 0f;
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
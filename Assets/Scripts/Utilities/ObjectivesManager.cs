using System;
using System.Collections.Generic;
using Player;
using UI;
using UnityEngine;
using Motion = Player.Motion;

namespace Utilities
{
    public class ObjectivesManager : MonoBehaviour
    {
        public static ObjectivesManager Instance;
        
        [SerializeField] private Objective[] objectives;
        [SerializeField] private bool allObjectivesComplete;
        
        private GameObject _player;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UIManager.Instance.UpdateObjectivesText(GetObjectives());
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
            UIManager.Instance.UpdateObjectivesText(GetObjectives());
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
                _player.GetComponent<Motion>().enabled = false;
                _player.GetComponent<Look>().enabled = false;
                InputManager.Instance.CursorLock(false);
                GameEvents.Instance.GameComplete();
            }
        }
        
        public List<Tuple<bool, string>> GetObjectives()
        {
            List<Tuple<bool, string>> allObjectives = new List<Tuple<bool, string>>();

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


        [Serializable]
        public class Objective
        {
            public int objectiveID;
            public string objectiveName;
            public bool completed;
            public bool finalObjective;
        }
    }
}
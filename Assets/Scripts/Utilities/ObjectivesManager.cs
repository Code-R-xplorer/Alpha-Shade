using System;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Utilities
{
    public class ObjectivesManager : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        public static ObjectivesManager Instance;
        
        [SerializeField] private Objective[] objectives;
        [SerializeField] private bool allObjectivesComplete;
        
        private GameObject _player;
        private bool _primaryComplete;

        private bool _primaryUnlocked;
        private bool _secondaryUnlocked;

        private int _primaryLockedCount;
        private int _secondaryLockedCount;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UpdateObjectiveUI();
            foreach (var objective in objectives)
            {
                if (objective.objectiveType == Type.Primary)
                {
                    if (objective.locked) _primaryLockedCount++;
                }
                else
                {
                    if (objective.locked) _secondaryLockedCount++;
                }
            }
        }

        public void ObjectiveComplete(int objectiveID)
        {
            foreach (var objective in objectives)
            {
                if (objective.objectiveID == objectiveID)
                {
                    if (objective.objectiveType == Type.Primary && !objective.locked)
                    {
                        if (objective.finalObjective)
                        {
                            if (!PrimaryComplete())
                            {
                                return;
                            }
                        }
                        objective.completed = true;
                        if (PrimaryUnlockedComplete() && !_primaryUnlocked)
                        {
                            UnlockObjectives(new Tuple<int, int>(objective.objectiveID + 1, objective.objectiveID + _primaryLockedCount));
                            _primaryUnlocked = true;
                        }
                    }

                    if (objective.objectiveType == Type.Secondary && !objective.locked)
                    {
                        // if(!PrimaryComplete()) return;
                        objective.completed = true;
                        if (SecondaryUnlockedComplete() && !_secondaryUnlocked)
                        {
                            UnlockObjectives(new Tuple<int, int>(objective.objectiveID + 1, objective.objectiveID + _secondaryLockedCount));
                            _secondaryUnlocked = true;
                        }
                    }
                }
            } 
            UpdateObjectiveUI();
        }

        private void UpdateObjectiveUI()
        {
            UIManager.Instance.UpdateObjectivesText(GetObjectives());
            
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

        private bool PrimaryComplete()
        {
            bool primaryComplete = true;
            foreach (var objective in objectives)
            {
                if(objective.objectiveType == Type.Secondary) continue;
                if (!objective.completed)
                {
                    primaryComplete = false;
                    break;
                }
            }

            return primaryComplete;
        }
        
        private bool ShowSecondaryObjectives()
        {
            bool showSecondary = true;
            foreach (var objective in objectives)
            {
                if(objective.objectiveType == Type.Secondary) continue;
                if (!objective.completed && !objective.finalObjective)
                {
                    showSecondary = false;
                    break;
                }
            }

            return showSecondary;
        }

        private bool PrimaryUnlockedComplete()
        {
            bool primaryUnlockedComplete = true;
            foreach (var objective in objectives)
            {
                if(objective.objectiveType == Type.Secondary) continue;
                if (!objective.completed && !objective.locked)
                {
                    primaryUnlockedComplete = false;
                    break;
                }
            }

            return primaryUnlockedComplete;
        }

        private bool SecondaryUnlockedComplete()
        {
            bool secondaryUnlockedComplete = true;
            foreach (var objective in objectives)
            {
                if(objective.objectiveType == Type.Primary) continue;
                if (!objective.completed && !objective.locked)
                {
                    secondaryUnlockedComplete = false;
                    break;
                }
            }

            return secondaryUnlockedComplete;
        }


        public void CheckComplete()
        {
            if (PrimaryComplete())
            {
                GameEvents.Instance.GameComplete();
            }
        }
        
        public List<Tuple<bool, string>> GetObjectives()
        {
            List<Tuple<bool, string>> allObjectives = new List<Tuple<bool, string>>();

            if (ShowSecondaryObjectives())
            {
                foreach (var objective in objectives)
                {
                    if((objective.objectiveType == Type.Primary || objective.locked) && !objective.finalObjective) continue;
                    allObjectives.Add(new Tuple<bool, string>(objective.completed, objective.name));
                }
            }
            else
            {
                foreach (var objective in objectives)
                {
                    if(objective.objectiveType == Type.Secondary || objective.locked) continue;
                    allObjectives.Add(new Tuple<bool, string>(objective.completed, objective.name));
                }
            }

            return allObjectives;
        }

        public void UnlockObjectives(Tuple<int,int> range)
        {
            for (int i = range.Item1; i <= range.Item2; i++)
            {
                objectives[i].locked = false;
            }
            UpdateObjectiveUI();
        }

        public string GetCurrentObjective()
        {
            foreach (var objective in objectives)
            {
                if (!objective.completed)
                {
                    return objective.name;
                }
            }

            return "";
        }


        [Serializable]
        public class Objective
        {
            public string name;
            public int objectiveID;
            public bool completed;
            public bool locked;
            public Type objectiveType;
            public bool finalObjective;
        }
        
        public enum Type
        {
            Primary,
            Secondary
        }
    }
}
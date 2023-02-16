using System;
using System.Collections.Generic;
using Player;
using TMPro;
using UnityEngine;
using Utilities;

namespace UI.Pocket_Watch
{
    public class ObjectivesScreen : BaseScreen
    {
        private GameManager gameManager;
        [SerializeField] private TextMeshProUGUI objectiveText;
        public override void Init(PocketWatch pw, GameObject p)
        {
            base.Init(pw, p);
            gameManager = GameManager.Instance;
        }

        public void UpdateObjectivesScreen(List<Tuple<bool, string>> objectiveList)
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

            objectiveText.text = objectivesString;
        }
    }
}
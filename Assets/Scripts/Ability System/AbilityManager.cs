using System.Collections.Generic;
using Managers;
using Player;
using UI.RadialMenu;
using UnityEngine;
using Utilities;

namespace Ability_System
{
    public class AbilityManager : MonoBehaviour, IDisplayText
    {
        public List<Ability> abilities;
        private Dictionary<string, Ability> _abilities;
        [HideInInspector]
        public GameObject player;

        public Ability selectedAbility;

        private Ability prevSelected;

        private RadialMenu radialMenu;

        private void Start()
        {
            InputManager.Instance.OnFire += Fire;
            StateManager.Instance.OnStateChange += DeactivateAbilities;
            player = GameObject.FindWithTag(Tags.Player);
            radialMenu = GameObject.Find("RadialMenu").GetComponent<RadialMenu>();

            abilities = new List<Ability>();
            abilities.AddRange(transform.GetComponentsInChildren<Ability>());

            _abilities = new Dictionary<string, Ability>();
            foreach (var ability in abilities)
            {
                _abilities.Add(ability.abilityName, ability);
                _abilities[ability.abilityName].Initialization(this);
                radialMenu.AddMenuItem(_abilities[ability.abilityName], this);
            }

            gameObject.SetActive(false);
        }

        private void DeactivateAbilities(StateManager.States states)
        {
            if (states != StateManager.States.Ability)
            {
                gameObject.SetActive(false);
                prevSelected = null;
            }
        }

        public void SelectAbility(string abilityName)
        {
            var checkDict = _abilities.TryGetValue(abilityName, out selectedAbility);
            if (checkDict)
            {
                if (selectedAbility == prevSelected &&
                    StateManager.Instance.GetCurrentState() == StateManager.States.Ability)
                {
                    StateManager.Instance.SetState(StateManager.States.Normal);
                    selectedAbility.selected = false;
                    return;
                }
                if(prevSelected != null) prevSelected.selected = false;
                prevSelected = selectedAbility;
                StateManager.Instance.SetState(StateManager.States.Ability);
                selectedAbility.selected = true;
                gameObject.SetActive(true);
            }
        }

        private void Fire(bool canceled)
        {
            if (!gameObject.activeSelf) return;
            if (!canceled)
            {
                if (selectedAbility == null) return;
                selectedAbility.Action();
            }
        }


        public string GetDisplayText()
        {
            return prevSelected == null ? "Ability: None" : $"Ability: {selectedAbility.abilityName}";
        }
    }
}
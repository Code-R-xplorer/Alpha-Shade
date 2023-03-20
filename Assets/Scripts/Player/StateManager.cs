using System;
using Ability_System;
using Gun_System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class StateManager : MonoBehaviour
    {
        public static StateManager Instance;
        [SerializeField] private States currentState = States.Normal;

        private void Awake()
        {
            Instance = this;
        }

        public void SetState(States newState)
        {
            if(newState == currentState) return;
            currentState = newState;
            StateChange(currentState);
        }

        public States GetCurrentState()
        {
            return currentState;
        }

        public event Action<States> OnStateChange;
        private void StateChange(States state) { OnStateChange?.Invoke(state); }
        public enum States
        {
            Normal,
            Gun,
            Ability,
            Hacking
        }
    }
}
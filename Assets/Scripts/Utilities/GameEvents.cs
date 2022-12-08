using System;
using UnityEngine;

namespace Utilities
{
    public class GameEvents : MonoBehaviour
    {
        public static GameEvents Instance;

        private void Awake()
        {
            Instance = this;
        }

        public event Action<Transform,bool> OnHeardSomething;
        public void HeardSomething(Transform input, bool agent)
        {
            OnHeardSomething?.Invoke(input, agent);
        }

        public event Action OnPlayerDeath;
        public void PlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }
    }
}

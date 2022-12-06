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

        public event Action<Transform,bool> onHeardSomething;
        public void HeardSomething(Transform input, bool agent)
        {
            if(onHeardSomething != null)
            {
                onHeardSomething(input, agent);
            }
        }
    }
}

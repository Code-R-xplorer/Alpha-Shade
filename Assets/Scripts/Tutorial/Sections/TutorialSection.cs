using Interactables;
using UnityEngine;

namespace Tutorial.Sections
{
    public class TutorialSection : MonoBehaviour
    {
        [Header("Doors")]
        public Door endDoor;
        public Door nextSectionDoor;

        protected bool sectionStarted;

        public virtual void StartSection()
        {
            sectionStarted = true;
        }

        public void ExitSection()
        {
            sectionStarted = false;
        }
    }
}
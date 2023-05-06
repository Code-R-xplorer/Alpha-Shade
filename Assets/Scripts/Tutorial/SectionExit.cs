using Tutorial.Sections;
using UnityEngine;
using Utilities;

namespace Tutorial
{
    public class SectionExit : MonoBehaviour
    {
        private TutorialSection _section;

        private void Start()
        {
            _section = transform.parent.parent.GetComponent<TutorialSection>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                _section.ExitSection();
            }
        }
    }
}
using System;
using Tutorial.Sections;
using UnityEngine;
using Utilities;

namespace Tutorial
{
    public class SectionEnter : MonoBehaviour
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
                _section.StartSection();
            }
        }
    }
}
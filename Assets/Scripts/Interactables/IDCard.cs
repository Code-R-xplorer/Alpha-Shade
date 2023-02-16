using System;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class IDCard : MonoBehaviour
    {
        [SerializeField] private string idName;
        [SerializeField] private AccessLevel accessLevel;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player)) return;
            IDManager.Instance.IDCardCollected(this);
            Destroy(gameObject);
        }

        public string GetIDName()
        {
            return idName;
        }

        public AccessLevel GetAccessLevel()
        {
            return accessLevel;
        }
    }
}

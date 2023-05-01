using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class IDCard : MonoBehaviour
    {
        [SerializeField] private string idName;
        [SerializeField] private AccessLevel accessLevel;

        [SerializeField] private List<GameObject> models;

        private void Awake()
        {
            foreach (var model in models)
            {
                model.SetActive(false);
            }
        }

        private void Start()
        {
            models[(int)accessLevel-1].SetActive(true);
        }

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

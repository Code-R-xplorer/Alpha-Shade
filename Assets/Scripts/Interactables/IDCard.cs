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

        private bool _stopDraw;

        private void Start()
        {
            models[(int)accessLevel-1].SetActive(true);
            _stopDraw = true;
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

        private void OnDrawGizmos()
        {
            if (_stopDraw) return;
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(transform.position, new Vector3(1, 0.1f,0.5f));
        }
    }
}

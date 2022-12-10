using System;
using System.Collections;
using UnityEngine;
using Utilities;

namespace Tasks
{
    public class DataDownload : MonoBehaviour
    {
        [SerializeField] private float downloadTime = 5f;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                GameManager.Instance.ObjectiveComplete(3);
                StartCoroutine(DownloadData());
            }
        }

        private IEnumerator DownloadData()
        {
            yield return new WaitForSeconds(downloadTime);
            GameManager.Instance.ObjectiveComplete(4);
        }
    }
}

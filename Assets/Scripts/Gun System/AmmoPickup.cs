using Managers;
using UnityEngine;
using Utilities;

namespace Gun_System
{
    public class AmmoPickup : MonoBehaviour
    {
        [SerializeField] private int amount;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(Tags.Player)) return;
            GunManager.Instance.AmmoCollected(amount);
            AudioManager.Instance.PlayOneShot("pickup");
            Destroy(gameObject);
        }
    }
}
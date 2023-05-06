using System;
using Managers;
using UnityEngine;
using Utilities;

namespace Gun_System
{
    public class GunPickup : MonoBehaviour
    {
        public int index;
        public new string name;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                GunManager.Instance.GunCollected(index);
                switch (name)
                {
                    case "Pistol":
                        AudioManager.Instance.PlayOneShot("pistolEquip");
                        break;
                    case "Rifle":
                        AudioManager.Instance.PlayOneShot("rifleEquip");
                        break;
                }
                
                Destroy(gameObject);
            }
        }
    }
}
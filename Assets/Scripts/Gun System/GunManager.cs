using System.Collections.Generic;
using Managers;
using Player;
using UI.RadialMenu;
using UnityEngine;

namespace Gun_System
{
    public class GunManager : MonoBehaviour
    {
        public static GunManager Instance;

        public int clipCount;
        

        private RadialMenu radialMenu;

        private List<bool> collected;

        private int prevActive;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            radialMenu = GameObject.Find("RadialMenu").GetComponent<RadialMenu>();
            StateManager.Instance.OnStateChange += HolsterWeapon;
            collected = new List<bool>();
            collected.Add(true);
            for (int i = 1; i < transform.childCount; i++)
            {
                collected.Add(false);
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        private void HolsterWeapon(StateManager.States states)
        {
            if(states != StateManager.States.Gun) SelectGun(0);
        }

        public void GunCollected(int index)
        {
            collected[index] = true;
            GameObject gun = transform.GetChild(index).gameObject;
            radialMenu.AddMenuItem(gun.name,index, gun.GetComponent<GunController>().gun);
        }

        public void AmmoCollected(int amount)
        {
            clipCount += amount;
        }

        public void SelectGun(int index)
        {
            if (prevActive == index) return;
            if (collected[index])
            {
                AudioManager.Instance.Play("weaponSwap", transform);
                transform.GetChild(prevActive).gameObject.SetActive(false);
                transform.GetChild(index).gameObject.SetActive(true);
                prevActive = index;
                StateManager.Instance.SetState(index == 0 ? StateManager.States.Normal : StateManager.States.Gun);
            }
        }

    }
}
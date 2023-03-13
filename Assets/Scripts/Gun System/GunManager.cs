using System;
using System.Collections.Generic;
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
            collected = new List<bool>();
            collected.Add(true);
            for (int i = 1; i < transform.childCount; i++)
            {
                collected.Add(false);
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        public void GunCollected(int index)
        {
            collected[index] = true;
            GameObject gun = transform.GetChild(index).gameObject;
            radialMenu.AddMenuItem(gun.name,index, gun.GetComponent<GunController>().gun);
        }

        public void SelectGun(int index)
        {
            if (prevActive == index) return;
            if (collected[index])
            {
                transform.GetChild(prevActive).gameObject.SetActive(false);
                transform.GetChild(index).gameObject.SetActive(true);
                prevActive = index;
            }
        }

    }
}
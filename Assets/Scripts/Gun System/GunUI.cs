using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gun_System
{
    public class GunUI : MonoBehaviour
    {
        private VerticalLayoutGroup verticalLayoutGroup;
        [SerializeField] private GameObject ammoImage;

        private int clipSize;
        

        private void Start()
        {
            verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
        }

        public void InitializeUI(int amount)
        {
            clipSize = amount;
            AddAmmoImages();
        }

        public void Reload()
        {
            if (transform.childCount > 0)
            {
                Debug.Log(transform.childCount);
                for (int i = transform.childCount; i > 0; i--)
                {
                    DestroyImmediate(transform.GetChild(0).gameObject);
                }
            }
            AddAmmoImages();
        }

        private void AddAmmoImages()
        {
            verticalLayoutGroup.childControlHeight = true;
            verticalLayoutGroup.childForceExpandHeight = true;
            for (int i = 0; i < clipSize; i++)
            {
                Instantiate(ammoImage, transform, false);
            }


        }

        public void ReduceAmmo()
        {
            verticalLayoutGroup.childControlHeight = false;
            verticalLayoutGroup.childForceExpandHeight = false;
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
using System;
using Player;
using UnityEngine;

namespace UI.Pocket_Watch
{
    public class BaseScreen : MonoBehaviour
    {
        protected PocketWatch pocketWatch;
        protected GameObject player;

        private int screenIndex;

        private GameObject _uiParent;

        public int test;

        public virtual void Init(PocketWatch pw, GameObject p)
        {
            pocketWatch = pw;
            player = p;
            screenIndex = Convert.ToInt32(gameObject.name.Split("_")[1]);
            Debug.Log(screenIndex);
            _uiParent = transform.GetChild(0).gameObject;
            if(screenIndex != 0) _uiParent.SetActive(false);
            pocketWatch.OnChangeScreen += ShowScreen;
        }

        private void ShowScreen(int index)
        {
            if(screenIndex == index) _uiParent.SetActive(true);
            else _uiParent.SetActive(false);
        }
    }
}

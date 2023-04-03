using System;
using System.Collections.Generic;
using Interactables;
using UI.RadialMenu;
using UnityEngine;

namespace Utilities
{
    public class KeyCardManager : MonoBehaviour
    {
        public static KeyCardManager Instance;

        private KeyCardData _currentKey;
        private KeyCardData _prevKey;

        private RadialMenu _radialMenu;

        private List<KeyCardData> _keyCardsData;

        [SerializeField] private GameObject keyCardDataObject;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _radialMenu = GameObject.Find("RadialMenu").GetComponent<RadialMenu>();
            _keyCardsData = new List<KeyCardData>();
        }

        public void KeyCardCollected()
        {
            var idNumber = _keyCardsData.Count;
            var dataObject = Instantiate(keyCardDataObject, transform);
            var data = dataObject.GetComponent<KeyCardData>();
            data.Initialize(idNumber);
            _keyCardsData.Add(data);
            if (idNumber == 0)
            {
                _currentKey = _keyCardsData[0];
                _currentKey.selected = true;
            }
            _radialMenu.AddMenuItem(idNumber);
        }

        public void SelectKeyCard(int id)
        {
            if (_currentKey == _keyCardsData[id]) return;
            if(_prevKey != null) _prevKey.selected = false;
            _prevKey = _currentKey;
            _currentKey = _keyCardsData[id];
            _keyCardsData[_prevKey.id].selected = false;
            _keyCardsData[_currentKey.id].selected = true;
        }

        public bool TryKeyCard(string doorName)
        {
            if (_currentKey == null) return false;
            if (!_currentKey.inUse)
            {
                _currentKey.UseKeyCard(doorName);
                return true;
            }
            return false;
        }
        
        public bool CheckKeySelected(int id)
        {
            return _keyCardsData[id].selected;
        }

        public bool CheckKeyUsed(int id)
        {
            return _keyCardsData[id].inUse;
        }

        public string GetKeyCardDoorName(int id)
        {
            return _keyCardsData[id].doorName;
        }
    }
}
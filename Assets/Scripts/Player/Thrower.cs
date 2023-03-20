using System;
using Interactables;
using UnityEngine;
using Utilities;
using Random = UnityEngine.Random;

namespace Player
{
    public class Thrower : MonoBehaviour
    {
        [SerializeField] private int maxItems = 10;
        [SerializeField] private Transform hand;
        [SerializeField] private GameObject itemPrefab;
        private float throwForce;
        [SerializeField] private float minThrowForce = 1;
        [SerializeField] private float maxThrowForce = 5;
        
        private int _currentItems = 0;
        private InputManager _inputManager;
        private bool _itemHeld;
        private GameObject _currentItem;

        private void Start()
        {
            _inputManager = InputManager.Instance;
            _inputManager.OnThrow += ThrowItem;
            _currentItems = maxItems;
        }
        
        private void ThrowItem(bool canceled, double duration)
        {
            if (!canceled)
            {
                if (_currentItems > 0 && !_itemHeld)
                {
                    _currentItem = Instantiate(itemPrefab, hand);
                    _currentItem.transform.rotation = Random.rotation;
                    _currentItems--;
                    _itemHeld = true;
                }
            }
            else
            {
                if (_itemHeld)
                {
                    float dur = (float) duration;
                    dur = dur.Map(0, 5, 0, 1);
                    throwForce = Mathf.Lerp(minThrowForce, maxThrowForce, dur);
                    _currentItem.GetComponent<Throwable>().Throw(hand, throwForce);
                    _currentItem.transform.parent = null;
                    _itemHeld = false;
                }
            }
            
        }

        private void OnDestroy()
        {
            _inputManager.OnThrow -= ThrowItem;
        }
    }
    
    
}
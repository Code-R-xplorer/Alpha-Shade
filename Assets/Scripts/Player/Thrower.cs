using System;
using Interactables;
using UnityEngine;
using Utilities;

namespace Player
{
    public class Thrower : MonoBehaviour
    {
        [SerializeField] private int maxItems = 10;
        [SerializeField] private Transform hand;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private float throwForce = 5;
        
        private int _currentItems = 0;
        private InputManager _inputManager;
        private bool _itemHeld;
        private GameObject _currentItem;

        private void Start()
        {
            _inputManager = InputManager.Instance;
            _inputManager.OnThrow += ThrowItem;
        }

        public bool PickUpItem()
        {
            if (_currentItems < maxItems)
            {
                _currentItems++;
                return true;
            }

            return false;
        }

        private void ThrowItem(bool canceled)
        {
            if (!canceled)
            {
                if (_currentItems > 0 && !_itemHeld)
                {
                    _currentItem = Instantiate(itemPrefab, hand.position, UnityEngine.Random.rotation);
                    _currentItem.GetComponent<Throwable>().active = true;
                    _currentItem.transform.parent = hand;
                    _currentItem.transform.localPosition = Vector3.zero;
                    _currentItems--;
                    _itemHeld = true;
                }
            }
            // else
            // {
            //     if (_itemHeld)
            //     {
            //         _currentItem.transform.parent = null;
            //         Rigidbody itemRB = _currentItem.GetComponent<Rigidbody>();
            //         itemRB.isKinematic = false;
            //         itemRB.AddForce(hand.forward * throwForce, ForceMode.Impulse);
            //         _itemHeld = false;
            //     }
            // }
            
        }
    }
    
    
}
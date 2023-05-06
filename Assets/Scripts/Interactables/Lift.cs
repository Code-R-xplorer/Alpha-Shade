using System;
using Managers;
using UnityEngine;
using Utilities;

namespace Interactables
{
    public class Lift : MonoBehaviour
    {
        private Animator _animator;
        private static readonly int Open = Animator.StringToHash("Lift_Open");
        private static readonly int Close = Animator.StringToHash("Lift_Close");

        [SerializeField] private Transform groundFloor;
        [SerializeField] private Transform firstFloor;
        [SerializeField] private Transform secondFloor;

        private GameObject _player;

        private void Start()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AudioManager.Instance.Play("doorOpen", transform);
                _animator.Play(Open, -1, 0);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                AudioManager.Instance.Play("doorClose", transform);
                _animator.Play(Close, -1, 0);
            }
        }

        public void GoToFloor(int floor)
        {
            Transform newTransform = groundFloor;
            if (floor == 0) newTransform = groundFloor;
            if (floor == 1) newTransform = firstFloor;
            if (floor == 2) newTransform = secondFloor;
            
            GameManager.Instance.LoadFloor(floor);
            
            _player.transform.position = newTransform.position;
        }
    }
}
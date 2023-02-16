using System;
using UnityEditor.Animations;
using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private PlayerState currentState;
        [SerializeField] private Animator animator;

        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Sprint = Animator.StringToHash("Sprint");
        private static readonly int Shoot = Animator.StringToHash("Shoot");
        

        public void UpdateAnimation(PlayerState newState)
        {
            if(currentState == newState) return;
            switch (newState)
            {
                case PlayerState.Idle:
                    animator.SetTrigger(Idle);
                    break;
                case PlayerState.Walking:
                    animator.SetTrigger(Walk);
                    break;
                case PlayerState.Sprinting:
                    animator.SetTrigger(Sprint);
                    break;
                default:
                    // Debug.Log(newState + " has not been implemented");
                    break;
            }

            currentState = newState;
        }

        public void PlayShootAnim()
        {
            animator.SetTrigger(Shoot);
        }
        
    }
}
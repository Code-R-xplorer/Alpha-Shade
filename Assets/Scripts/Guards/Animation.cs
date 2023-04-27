using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using UnityEngine.Serialization;
using Utilities;

namespace Guards
{
    public class Animation : MonoBehaviour
    {
        private Animator _animator;
        private AnimationState _currentState = AnimationState.Default;
        private MasterState _masterState;

        private static readonly int RifleAimingIdle = Animator.StringToHash("Rifle Aiming Idle");
        private static readonly int RifleIdle = Animator.StringToHash("Rifle Idle");
        private static readonly int FiringRifle = Animator.StringToHash("Firing Rifle");
        private static readonly int RifleRun = Animator.StringToHash("Rifle Run");
        private static readonly int RifleWalk = Animator.StringToHash("Rifle Walk");
        private static readonly int Investigate = Animator.StringToHash("Investigate");
        private static readonly int Reloading = Animator.StringToHash("Reloading");

        private bool _usingGun;

        [HideInInspector]
        public GunController gun;

        [Header("Rigs")] 
        [SerializeField] private MultiAimConstraint bodyAimRig;
        [SerializeField] private MultiAimConstraint headAimRig;
        [SerializeField] private MultiAimConstraint aimRig;
        [SerializeField] private TwoBoneIKConstraint secondHandRig;

        private float _bodyAimStartWeight, _headAimRigStartWeight, _aimRigStartWeight, _secondHandRigStartWeight;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _bodyAimStartWeight = bodyAimRig.weight;
            _headAimRigStartWeight = headAimRig.weight;
            _aimRigStartWeight = aimRig.weight;
            _secondHandRigStartWeight = secondHandRig.weight;

            bodyAimRig.weight = 0;
            aimRig.weight = 0;
            secondHandRig.weight = 0;
        }

        public void PlayAnimation(Animations animations)
        {
            if(_masterState == MasterState.Normal) return;
            _currentState = AnimationState.Weapon;
            switch (animations)
            {
                case Animations.Shooting:
                    bodyAimRig.weight = _bodyAimStartWeight;
                    headAimRig.weight = _headAimRigStartWeight;
                    aimRig.weight = _aimRigStartWeight;
                    secondHandRig.weight = _secondHandRigStartWeight;
                    _animator.Play(FiringRifle, -1, 0f);
                    break;
                case Animations.Reloading:
                    bodyAimRig.weight = 0;
                    headAimRig.weight = _headAimRigStartWeight;
                    aimRig.weight = 0;
                    secondHandRig.weight = 0;
                    _animator.Play(Reloading, -1, 0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(animations), animations, null);
            }
        }

        public void ChangeMasterState(MasterState newState)
        {
            _masterState = newState;
        }


        public void ChangeState(AnimationState newState)
        {
            if (newState == _currentState) return;
            switch (newState)
            {
                case AnimationState.Idle:
                    if (_masterState == MasterState.Weapon) return;
                    bodyAimRig.weight = 0;
                    headAimRig.weight = _headAimRigStartWeight;
                    aimRig.weight = 0;
                    secondHandRig.weight = 0;
                    _animator.Play(RifleIdle, -1, 0f);
                    break;
                case AnimationState.Patrolling:
                    if (_masterState == MasterState.Weapon) return;
                    bodyAimRig.weight = 0;
                    headAimRig.weight = _headAimRigStartWeight;
                    aimRig.weight = 0;
                    secondHandRig.weight = 0;
                    _animator.Play(RifleWalk, -1, 0f);
                    break;
                case AnimationState.Chasing:
                    bodyAimRig.weight = _bodyAimStartWeight;
                    headAimRig.weight = _headAimRigStartWeight;
                    aimRig.weight = _aimRigStartWeight;
                    secondHandRig.weight = _secondHandRigStartWeight;
                    _animator.Play(RifleRun, -1, 0f);
                    break;
                case AnimationState.Investigate:
                    if (_masterState == MasterState.Weapon) return;
                    bodyAimRig.weight = 0;
                    headAimRig.weight = 0;
                    aimRig.weight = 0;
                    secondHandRig.weight = 0;
                    _animator.SetTrigger(Investigate);
                    break;
                case AnimationState.Search:
                    if (_masterState == MasterState.Weapon) return;
                    Debug.Log("Search");
                    bodyAimRig.weight = _bodyAimStartWeight;
                    headAimRig.weight = _headAimRigStartWeight;
                    aimRig.weight = _aimRigStartWeight;
                    secondHandRig.weight = _secondHandRigStartWeight;
                    _animator.Play(RifleAimingIdle, -1, 0f);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
            }

            _currentState = newState;
        }

        public void ToggleWeapon()
        {
            gun.ToggleGun();
        }

        public void AudioEvent(string audioName)
        {
            if (audioName == "walk")
            {
                AudioManager.Instance.PlayRandom(new []{"walk1", "walk2", "walk3", "walk4", "walk5"},transform);
            }

            if (audioName == "run")
            {
                AudioManager.Instance.PlayRandom(new []{"run1", "run2", "run3", "run4", "run5"},transform);
            }
        }


        public enum AnimationState
        {
            Idle,
            Patrolling,
            Chasing,
            Investigate,
            Search,
            Weapon,
            Default
        }
        
        public enum Animations
        {
            Shooting,
            Reloading
        }

        public enum MasterState
        {
            Normal,
            Weapon
        }

        private void OnEnable()
        {
            ChangeState(AnimationState.Idle);
        }

        private void OnDisable()
        {
            _currentState = AnimationState.Default;
        }
    }
}
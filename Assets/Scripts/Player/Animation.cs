using System;
using Gun_System;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Utilities;

namespace Player
{
    public class Animation : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private AnimatorOverrideController animatorOverrideController;
        private AnimationClipOverrides clipOverrides;

        [SerializeField] private MultiAimConstraint bodyAimRig;
        [SerializeField] private Rig rig;
        
        private static readonly int WeaponEquipped = Animator.StringToHash("weaponEquipped");
        private static readonly int Speed = Animator.StringToHash("speed");
        private static readonly int Shoot = Animator.StringToHash("shoot");
        private static readonly int Holster = Animator.StringToHash("holster");
        private static readonly int Reload = Animator.StringToHash("reload");

        [SerializeField] private Vector3[] offsets;

        private float speed;
        private bool shooting;

        private void Awake()
        {
            animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
            animator.runtimeAnimatorController = animatorOverrideController;

            clipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
            animatorOverrideController.GetOverrides(clipOverrides);

        }

        private void Start()
        {
            PlayHolsterAnim();
        }

        private void Update()
        {
            if (speed > 1)
            {
                bodyAimRig.data.offset = offsets[1];
            }
            else if (speed < 1)
            {
                bodyAimRig.data.offset = offsets[0];
            }
            
            if (shooting)
            {
                bodyAimRig.data.offset = offsets[2];
            }
        }

        public void UpdateSpeed(float speedT)
        {
            speed = speedT;
            animator.SetFloat(Speed, speedT);
        }

        public void PlayShootAnim()
        {
            animator.SetTrigger(Shoot);
        }

        public void PlayHolsterAnim()
        {
            animator.SetTrigger(Holster);
        }

        public void PlayReloadAnim()
        {
            animator.SetTrigger(Reload);
        }

        public void AnimStart(string animName)
        {
            if (animName == "Shoot")
            {
                shooting = true;
            }

            if (animName == "Holster")
            {
                rig.weight = 0;
            }
        }

        public void AnimEnd(string animName)
        {
            if (animName == "Shoot")
            {
                shooting = false;
            }

            if (animName == "Holster")
            {
                rig.weight = 1;
            }
        }


    }
}
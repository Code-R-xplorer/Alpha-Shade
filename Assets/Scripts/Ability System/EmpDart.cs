using System;
using Interactables;
using Managers;
using UnityEngine;
namespace Ability_System
{
    public class EmpDart : Ability
    {
        public float range;
        public float stunDuration;
        public GameObject dartPrefab;

        private LayerMask _layerMask;

        public override void Initialization(AbilityManager abilityManager)
        {
            base.Initialization(abilityManager);
            _layerMask = LayerMask.GetMask("Player");
        }

        public override void Action()
        {
            base.Action();
            if (uses <= 0 || inCooldown)
            {
                if(used) return;
            }
            RaycastHit hit;
            var transform1 = Camera.main.transform;
            Ray ray = new Ray(transform1.position, transform1.forward);
            Debug.DrawRay(ray.origin, ray.direction * range, Color.blue, 20f);
            if (Physics.Raycast(ray, out hit, range, ~_layerMask))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    used = true;
                    inCooldown = true;
                    GameObject dart = Instantiate(dartPrefab, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    dart.transform.SetParent(hit.collider.transform);
                    dart.GetComponent<Dart>().duration = stunDuration;
                }
            }
        }
    }
}
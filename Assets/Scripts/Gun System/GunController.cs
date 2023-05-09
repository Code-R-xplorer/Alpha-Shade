using System;
using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

namespace Gun_System
{
    public class GunController : MonoBehaviour
    {

        [FormerlySerializedAs("Gun")] public Gun gun;

        private float _lastFired;

        private InputManager inputManager;
        private bool canFire;
        private bool fired;
        private LayerMask _layerMask;
        [SerializeField] private GameObject muzzleFlashPrefab;
        [SerializeField] private GunUI gunUI;

        private GunManager gunManager;

        private void Start()
        {
            inputManager = InputManager.Instance;
            inputManager.OnFire += TriggerFire;
            inputManager.OnReload += Reload;
            gun.currentAmmo = gun.clipSize;
            _layerMask = LayerMask.GetMask("Player", "Door");
            
            gunUI.InitializeUI(gun.clipSize);
            
            gunManager = GunManager.Instance; 


        }

        private void Update()
        {
            if (!gameObject.activeSelf) return;
            if (gun.semiAutomatic)
            {
                if (canFire && !fired && Time.time > _lastFired + gun.fireRate)
                {
                    Fire();
                }
            }
            else
            {
                if (canFire && Time.time > _lastFired + gun.fireRate)
                {
                    Fire();
                }
            }
        }

        private void Fire()
        {
            if (gun.currentAmmo > 0)
            {
                switch (gun.name)
                {
                    case "Pistol":
                        AudioManager.Instance.Play("pistolShoot", transform);
                        break;
                    case "Rifle":
                        AudioManager.Instance.Play("rifleShoot", transform);
                        break;
                }

                // decrease the ammo count
                gun.currentAmmo--;
                
                gunUI.ReduceAmmo();
                
                // animation.PlayShootAnim();
                SpawnFX();
                
                Ray ray = new Ray(gun.firePoint.position, gun.firePoint.forward);
                Debug.DrawRay(ray.origin, ray.direction * gun.range, Color.blue, 20f);
                if (Physics.Raycast(ray, out var hit, gun.range, ~_layerMask))
                {
                    var guard = hit.collider.gameObject;
                    if (hit.collider.CompareTag("GuardBack") || hit.collider.CompareTag("GuardVision"))
                    {
                        guard = hit.collider.transform.parent.gameObject;
                    }
                    
                    IDamageable damageable = guard.GetComponent<Collider>().GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(gun.damage);
                    }
                    
                    GameObject decal = Instantiate(gun.hitDecal, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal));
                    decal.transform.SetParent(hit.collider.transform);
                }
                _lastFired = Time.time;
                fired = true;
            }
            else
            {
                switch (gun.name)
                {
                    case "Pistol":
                        AudioManager.Instance.Play("pistolEmpty", transform);
                        break;
                    case "Rifle":
                        AudioManager.Instance.Play("rifleEmpty", transform);
                        break;
                }
            }
        }

        private void TriggerFire(bool canceled)
        {
            canFire = !canceled;
            if (canceled) fired = false;
        }

        private void Reload()
        {
            if (!gameObject.activeSelf) return;
            if (gun.currentAmmo < gun.clipSize && gunManager.clipCount > 0)
            {
                gun.currentAmmo = gun.clipSize;
                gunManager.clipCount--;
                gunUI.Reload();
                switch (gun.name)
                {
                    case "Pistol":
                        AudioManager.Instance.Play("pistolReload", transform);
                        break;
                    case "Rifle":
                        AudioManager.Instance.Play("rifleReload", transform);
                        break;
                }
            }
        }

        private void SpawnFX()
        {
            GameObject fx = Instantiate(muzzleFlashPrefab, gun.firePoint);
            StartCoroutine(DestroyFX(fx));
        }

        private IEnumerator DestroyFX(GameObject objectToDestroy)
        {
            yield return new WaitForSeconds(1);
            Destroy(objectToDestroy);
            
        }
        
    }
    [Serializable]
    public class Gun
    {
        public string name;
        public bool semiAutomatic;
        public int clipSize;
        public int currentAmmo;
        public float fireRate;
        public float damage;
        public float range;
        public Transform firePoint;
        public GameObject hitDecal;

    }
}

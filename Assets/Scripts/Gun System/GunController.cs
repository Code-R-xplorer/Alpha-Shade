using System;
using System.Collections;
using Player;
using UnityEngine;
using Utilities;

namespace Gun_System
{
    public class GunController : MonoBehaviour
    {
        [SerializeField] private GunData gun;

        private float _lastFired;

        private InputManager inputManager;
        private bool canFire;
        private bool fired;
        private LayerMask _layerMask;
        [SerializeField] private PlayerAnimation playerAnimation;
        [SerializeField] private GameObject muzzleFlashPrefab;
        [SerializeField] private Transform muzzlePoint;
        [SerializeField] private GunUI gunUI;

        private void Start()
        {
            inputManager = InputManager.Instance;
            inputManager.OnFire += TriggerFire;
            inputManager.OnReload += Reload;
            gun = Utils.Clone(gun);
            gun.currentAmmo = gun.clipSize;
            gun.firePoint = Camera.main.transform;
            _layerMask = LayerMask.GetMask("Player");
            gunUI.InitializeUI(gun.clipSize);
            

        }

        private void Update()
        {
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
                // decrease the ammo count
                gun.currentAmmo--;
                
                gunUI.ReduceAmmo();
                
                playerAnimation.PlayShootAnim();
                SpawnFX();
                

                // play the fire sound
                // AudioSource.PlayClipAtPoint(data.fireSound, transform.position);

                // shoot a raycast to detect hits
                // RaycastHit hit = Physics.Raycast(data.firePoint.position, data.firePoint.right, data.range);
                // Debug.Log("Fire");
                RaycastHit hit;
                Ray ray = new Ray(gun.firePoint.position, gun.firePoint.forward);
                Debug.DrawRay(ray.origin, ray.direction * gun.range, Color.blue, 20f);
                if (Physics.Raycast(ray, out hit, gun.range, ~_layerMask))
                {
                    GameObject guard;
                    guard = hit.collider.gameObject;
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
                // play the out of ammo sound
                // AudioSource.PlayClipAtPoint(data.outOfAmmoSound, transform.position);
            }
        }

        private void TriggerFire(bool canceled)
        {
            canFire = !canceled;
            if (canceled) fired = false;
        }

        private void Reload()
        {
            if (gun.currentAmmo < gun.clipSize && gun.clipCount > 0)
            {
                gun.currentAmmo = gun.clipSize;
                gun.clipCount--;
                gunUI.Reload();
            }
        }

        private void SpawnFX()
        {
            GameObject fx = Instantiate(muzzleFlashPrefab, muzzlePoint);
            StartCoroutine(DestroyFX(fx));
        }

        private IEnumerator DestroyFX(GameObject objectToDestroy)
        {
            yield return new WaitForSeconds(1);
            Destroy(objectToDestroy);
            
        }
        
    }
}

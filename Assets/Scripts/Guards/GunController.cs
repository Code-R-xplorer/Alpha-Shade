using System;
using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

namespace Guards
{
    public class GunController : MonoBehaviour
    {

        public Gun gun;

        private float _lastFired;
        
        public bool fire;
        private bool _reloading;
        private LayerMask _layerMask;
        [SerializeField] private GameObject muzzleFlashPrefab;

        [FormerlySerializedAs("animation")] [HideInInspector]
        public Animation _animation;

        private bool _show = true;

        private void Start()
        {
            gun.currentAmmo = gun.clipSize;
            _layerMask = LayerMask.GetMask("Guard", "Door");

        }

        private void Update()
        {
            if (!gameObject.activeSelf) return;
            
            if (fire && Time.time > _lastFired + gun.fireRate && !_reloading)
            {
                Fire();
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
                _animation.PlayAnimation(Animation.Animations.Shooting);
                // decrease the ammo count
                gun.currentAmmo--;

                // animation.PlayShootAnim();
                SpawnFX();


                // play the fire sound
                // AudioSource.PlayClipAtPoint(data.fireSound, transform.position);

                // shoot a raycast to detect hits
                // RaycastHit hit = Physics.Raycast(data.firePoint.position, data.firePoint.right, data.range);
                // Debug.Log("Fire");   
                Ray ray = new Ray(gun.firePoint.position, gun.firePoint.forward);
                Debug.DrawRay(ray.origin, ray.direction * gun.range, Color.blue, 20f);
                if (Physics.Raycast(ray, out var hit, gun.range, ~_layerMask))
                {
                    var player = hit.collider.gameObject;

                    IDamageable damageable = player.GetComponent<Collider>().GetComponent<IDamageable>();
                    if (damageable != null)
                    {
                        damageable.TakeDamage(gun.damage);
                    }
                }
                _lastFired = Time.time; 
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
                Reload();
            }
        }

        private void Reload()
        {
            if (!gameObject.activeSelf) return;
            if (gun.currentAmmo < gun.clipSize && !_reloading)
            {
                switch (gun.name)
                {
                    case "Pistol":
                        AudioManager.Instance.Play("pistolReload", transform);
                        break;
                    case "Rifle":
                        AudioManager.Instance.Play("rifleReload", transform);
                        break;
                }
                StartCoroutine(ReloadTimer());
            }
        }

        private IEnumerator ReloadTimer()
        {
            _animation.PlayAnimation(Animation.Animations.Reloading);
            _reloading = true;
            yield return new WaitForSeconds(3.4f);
            _reloading = false;
            gun.currentAmmo = gun.clipSize;
        }

        private void SpawnFX()
        {
            var fx = Instantiate(muzzleFlashPrefab, gun.firePoint);
            StartCoroutine(DestroyFX(fx));
        }

        private IEnumerator DestroyFX(GameObject objectToDestroy)
        {
            yield return new WaitForSeconds(1);
            Destroy(objectToDestroy);
            
        }

        public void ToggleGun()
        {
            _show = !_show;
            gameObject.SetActive(_show);
            AudioManager.Instance.Play("weaponSwap", transform);
        }

        public void ShowGun()
        {
            if (_show) return;
            _show = true;
            gameObject.SetActive(true);
            AudioManager.Instance.Play("weaponSwap", transform);
        }
        
    }
    [Serializable]
    public class Gun
    {
        public string name;
        public int clipSize;
        public int currentAmmo;
        public float fireRate;
        public float damage;
        public float range;
        public Transform firePoint; 
    }
}

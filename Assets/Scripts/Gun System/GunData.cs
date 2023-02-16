using UnityEngine;

namespace Gun_System
{
    [CreateAssetMenu(menuName = "Gun Data")]
    public class GunData : ScriptableObject
    {
        public bool semiAutomatic;
        public int clipSize;
        public int clipCount;
        public int currentAmmo;
        public float fireRate;
        public float damage;
        public float range;
        public Transform firePoint;
        public GameObject hitDecal;
    }
}

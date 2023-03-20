using Gun_System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.RadialMenu
{
    public class WeaponMenuItem : ItemBase
    {
        private Gun gun;
        private int gunIndex;

        private string heading;
        private string body;
        private bool isGunNull;

        public void Initialize(string gName, int index, Gun gGun)
        {
            gunIndex = index;
            gun = gGun;

            heading = $"Gun: {gName}";
            body = $"Available Clips: {GunManager.Instance.clipCount} " +
                   $"Clip Size: {gun.clipSize} \n" +
                   $"Current Ammo: {gun.currentAmmo} \n" +
                   $"Fire Rate: {gun.fireRate}s \n" +
                   $"Damage: {gun.damage} \n" +
                   $"Range: {gun.range}m";
            isGunNull = gun == null;
        }

        protected override void Start()
        {
            isGunNull = gun == null;
            base.Start();
            if (gun == null)
            {
                heading = "Holster";
                body = $"Available Clips: {GunManager.Instance.clipCount}";
            }
            
        }

        public override void OnHover()
        {
            base.OnHover();
            if (isGunNull)
            {
                body = $"Available Clips: {GunManager.Instance.clipCount}";
            }
            else
            {
                body = $"Available Clips: {GunManager.Instance.clipCount} " +
                       $"Clip Size: {gun.clipSize} \n" +
                       $"Current Ammo: {gun.currentAmmo} \n" +
                       $"Fire Rate: {gun.fireRate}s \n" +
                       $"Damage: {gun.damage} \n" +
                       $"Range: {gun.range}m";
            }
            infoDisplayTab.UpdateText(heading, body);
        }

        public override void OnPerformAction()
        {
            base.OnPerformAction();
            GunManager.Instance.SelectGun(gunIndex);
        }
    }
}
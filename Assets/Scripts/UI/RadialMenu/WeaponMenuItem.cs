using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.RadialMenu
{
    public class WeaponMenuItem : ItemBase
    {
        [SerializeField] private GameObject gunPrefab;

        public override void OnPerformAction()
        {
            base.OnPerformAction();
            Debug.Log( transform.parent.name + " " + gameObject.name);
        }
    }
}
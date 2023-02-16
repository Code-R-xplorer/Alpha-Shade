using System;
using System.Globalization;
using Player;
using TMPro;
using UnityEngine;

namespace UI.Pocket_Watch
{
    public class HealthScreen : BaseScreen
    {
        [SerializeField] private TextMeshProUGUI healthText;

        private PlayerHealth _playerHealth;

        public override void Init(PocketWatch pw, GameObject p)
        {
            base.Init(pw, p);
            _playerHealth = player.GetComponent<PlayerHealth>();
            healthText.text = _playerHealth.GetHealth().ToString();
        }

        private void Update()
        {
            healthText.text = _playerHealth.GetHealth().ToString();
        }
    }
}

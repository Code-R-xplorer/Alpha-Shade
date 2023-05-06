using System;
using System.Collections;
using System.Net.NetworkInformation;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace UI
{
    public class ModalWindowPanel : MonoBehaviour
    {
        [Header("Header")] 
        [SerializeField] private GameObject headerArea;
        [SerializeField] private TextMeshProUGUI titleField;

        [Header("Content")] 
        [SerializeField] private GameObject contentArea;
        [SerializeField] private GameObject verticalLayoutArea;
        [SerializeField] private Image heroImage;
        [SerializeField] private TextMeshProUGUI heroText;
        [Space] 
        [SerializeField] private GameObject horizontalLayoutArea;
        [SerializeField] private GameObject iconContainer;
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI iconText;

        [Header("Footer")] 
        [SerializeField] private GameObject footerArea;
        [SerializeField] private Button confirmButton;
        [SerializeField] private Button declineButton;
        [SerializeField] private Button alternateButton;

        private Action _onConfirmAction;
        private Action _onDeclineAction;
        private Action _onAlternateAction;

        public void Confirm()
        {
            Close();
            _onConfirmAction?.Invoke();
            // Close();
        }
        public void Decline()
        {
            Close();
            _onDeclineAction?.Invoke();
            // Close();
        }
        public void Alternate()
        {
            Close();
            _onAlternateAction?.Invoke();
            // Close();
        }
        private void Close()
        {
            InputManager.Instance.CursorLock(true);
            gameObject.SetActive(false);
            Time.timeScale = 1;
            UIManager.Instance.ToggleHUD(true);
            GameManager.Instance.canPause = true;
        }

        public void ShowAsHero(string title, Sprite imageToShow, string message, Action confirmAction,
            Action declineAction = null, Action alternateAction = null)
        {
            horizontalLayoutArea.SetActive(false);
            verticalLayoutArea.SetActive(true);

            bool hasTitle = !string.IsNullOrEmpty(title);
            headerArea.SetActive(hasTitle);
            titleField.text = title;

            heroImage.sprite = imageToShow;
            heroText.text = message;

            _onConfirmAction = confirmAction;

            bool hasDecline = declineAction != null;
            declineButton.gameObject.SetActive(hasDecline);
            _onDeclineAction = declineAction;

            bool hasAlternate = alternateAction != null;
            alternateButton.gameObject.SetActive(hasAlternate);
            _onAlternateAction = alternateAction;

            Invoke(nameof(Show), 0.01f);
            // Show();
        }

        private void Show()
        {
            UIManager.Instance.ToggleHUD(false);
            gameObject.SetActive(true);
            InputManager.Instance.CursorLock(false);
            Time.timeScale = 0;
            GameManager.Instance.canPause = false;
        }
    }
}
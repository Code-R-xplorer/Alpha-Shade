using System;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class DialogWindow : MonoBehaviour
    {
        [Header("Icon")] 
        [SerializeField] private GameObject iconHolder;
        [SerializeField] private Image iconImage;
        
        [Header("Dialog")]
        [SerializeField] private TextMeshProUGUI dialogText;
        
        private Action _onConfirmAction;

        private void Awake()
        {
            InputManager.Instance.OnAnyButtonPress += Confirm;
        }

        public void ShowDialog(Sprite imageToShow, string message, Action confirmCallback)
        {
            bool hasImage = imageToShow != null;
            iconHolder.SetActive(hasImage);
            iconImage.sprite = imageToShow;
            
            _onConfirmAction = confirmCallback;

            dialogText.text = message;
            
            Invoke(nameof(Show), 0.01f);
        }

        private void Show()
        {
            gameObject.SetActive(true);
            Time.timeScale = 0;
            GameManager.Instance.canPause = false;
        }

        private void Close()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            GameManager.Instance.canPause = true;
        }
        
        public void Confirm()
        {
            if (!gameObject.activeSelf) return;
            _onConfirmAction?.Invoke();
            Close();
        }
        
    }
}
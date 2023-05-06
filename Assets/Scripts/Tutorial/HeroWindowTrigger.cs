using System;
using Managers;
using UnityEngine;
using UnityEngine.Events;

namespace Tutorial
{
    public class HeroWindowTrigger : MonoBehaviour
    {
        public string title;
        public Sprite sprite;
        [TextArea]
        public string message;
        public bool triggerOnEnable = true;

        public UnityEvent onConfirmEvent;
        public UnityEvent onCancelEvent;
        public UnityEvent onAlternateEvent;

        private void OnEnable()
        {
            if(!triggerOnEnable) return;

            Action confirmCallback = null;
            Action cancelCallback = null;
            Action alternateCallback = null;

            if (onConfirmEvent.GetPersistentEventCount() > 0)
            {
                confirmCallback = onConfirmEvent.Invoke;
            }
            if (onCancelEvent.GetPersistentEventCount() > 0)
            {
                cancelCallback = onCancelEvent.Invoke;
            }
            if (onAlternateEvent.GetPersistentEventCount() > 0)
            {
                alternateCallback = onAlternateEvent.Invoke;
            }
            
            
            TutorialManager.Instance.ModalWindowPanel.ShowAsHero(title,sprite,message,confirmCallback, cancelCallback, alternateCallback);
        }
    }
}
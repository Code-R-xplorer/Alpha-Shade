using System;
using UnityEngine;
using UnityEngine.Events;

namespace Tutorial
{
    public class DialogWindowTrigger : MonoBehaviour
    {
        public Sprite sprite;
        [TextArea]
        public string message;
        public bool triggerOnEnable = true;

        public UnityEvent onConfirmEvent;

        private void OnEnable()
        {
            if(!triggerOnEnable) return;

            Action confirmCallback = null;

            if (onConfirmEvent.GetPersistentEventCount() > 0)
            {
                confirmCallback = onConfirmEvent.Invoke;
            }
            
            TutorialManager.Instance.DialogWindow.ShowDialog(sprite,message,confirmCallback);
        }
    }
}
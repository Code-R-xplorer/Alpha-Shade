using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utilities;

namespace Player
{
    public class Interact : MonoBehaviour
    {
        private LayerMask _layerMask;
        private void Start()
        {
            InputManager.Instance.OnStartInteract += InteractEvent;
            _layerMask = LayerMask.NameToLayer("UI");
        }

        private void InteractEvent()
        {
            RaycastHit hit;
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.green, 5f);
            if (Physics.Raycast(ray, out hit, 5f, _layerMask))
            {
                if (hit.collider.GetComponent<Button>() != null)
                {
                    BaseEventData baseEventData = new BaseEventData(EventSystem.current);
                    hit.collider.GetComponent<Button>().OnSubmit(baseEventData);
                }
            }
        }
    }
}
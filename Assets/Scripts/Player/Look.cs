using System;
using UnityEngine;
using Utilities;

namespace Player
{
    public class Look : MonoBehaviour
    {
        private InputManager _input;
        [SerializeField] private Transform player;
        [SerializeField] private Transform cam;
        [SerializeField] private float xSensitivity;
        [SerializeField] private float ySensitivity;

        [SerializeField] private float maxAngle;

        private Quaternion _camCenter;
        // Start is called before the first frame update
        private void Start()
        {
            _input = InputManager.Instance;
            _camCenter = cam.localRotation;
        }

        // Update is called once per frame
        private void Update()
        {
            if (Cursor.lockState == CursorLockMode.None) return;
            SetY();
            SetX();
        }

        private void SetY()
        {
            float input = _input.LookInput.y * ySensitivity * Time.deltaTime;
            Quaternion adj = Quaternion.AngleAxis(input, -Vector3.right);
            Quaternion delta = cam.localRotation * adj;

            if (Quaternion.Angle(_camCenter, delta) < maxAngle)
            {
                cam.localRotation = delta;
            }

            
        }

        private void SetX()
        {
            float input = _input.LookInput.x * xSensitivity * Time.deltaTime;
            Quaternion adj = Quaternion.AngleAxis(input, Vector3.up);
            Quaternion delta = player.localRotation * adj;
            player.localRotation = delta;
        }
        
        
    }
}

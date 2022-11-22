using UnityEngine;
using UnityEngine.TextCore.Text;
using Utilities;

namespace Player
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] private float sensX = 15f;

        [SerializeField] private float sensY = 15f;

        [SerializeField] private Transform _camera;
        [SerializeField] private Transform orientation;
        
        private InputManager _inputManager;

        private float _multiplier = 0.01f;

        private float _xRot, _yRot;
        // Start is called before the first frame update
        void Start()
        {
            _inputManager = InputManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            _yRot += _inputManager.LookInput.x * sensX * _multiplier;
            _xRot -= _inputManager.LookInput.y * sensY * _multiplier;

            _xRot = Mathf.Clamp(_xRot, -70f, 70f);

            _camera.transform.localRotation = Quaternion.Euler(_xRot,_yRot,0);
            orientation.transform.rotation = Quaternion.Euler(0, _yRot, 0);
        }
    }
}

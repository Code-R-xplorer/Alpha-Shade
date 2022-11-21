using System;
using UnityEngine;
using Utilities;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float playerHeight = 2f;
        [SerializeField] private Transform orientation;
        [Header("Movement")] 
        [SerializeField] private float moveSpeed = 6f;
        [SerializeField] private float groundDrag = 6f;
        [SerializeField] private float airDrag = 2f;

        private float _movementMultiplier = 10f;
        private float _airMovementMultiplier = 0.4f;
        private Vector3 _moveDirection;
        private Vector3 _slopeMoveDirection;
        private RaycastHit _slopeHit;
        private bool _isGrounded;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;
        

        [Header("Jumping")] 
        [SerializeField] private float jumpForce = 5f;

        private InputManager _inputManager;

        private Rigidbody _rb;
        // Start is called before the first frame update
        void Start()
        {
            _inputManager = InputManager.Instance;
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            _inputManager.OnStartJump += Jump;
        }

        // Update is called once per frame
        void Update()
        {
            _isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, playerHeight / 2, 0), groundDistance,
                groundMask);

            var transform1 = orientation;
            
            _moveDirection = transform1.forward * _inputManager.MovementInput.y +
                             transform1.right * _inputManager.MovementInput.x;
            if (_isGrounded) _rb.drag = groundDrag;
            else _rb.drag = airDrag;

            _slopeMoveDirection = Vector3.ProjectOnPlane(_moveDirection, _slopeHit.normal);
        }

        private void Jump()
        {
            if(_isGrounded) _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        private bool OnSlope()
        {
            if (Physics.Raycast(transform.position, Vector3.down, out _slopeHit, playerHeight / 2 + 0.5f))
            {
                return _slopeHit.normal != Vector3.up;
            }

            return false;
        }

        private void FixedUpdate()
        {
            if(_isGrounded && !OnSlope()) _rb.AddForce(_moveDirection.normalized * (moveSpeed * _movementMultiplier), ForceMode.Acceleration);
            else if(_isGrounded && OnSlope()) _rb.AddForce(_slopeMoveDirection.normalized * (moveSpeed * _movementMultiplier), ForceMode.Acceleration);
            else _rb.AddForce(_moveDirection.normalized * (moveSpeed * _movementMultiplier * _airMovementMultiplier), ForceMode.Acceleration);
            
        }
    }
}

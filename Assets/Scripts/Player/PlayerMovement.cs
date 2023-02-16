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
        [SerializeField] private float crouchSpeed = 3f;
        [SerializeField] private float walkSpeed = 6f;
        [SerializeField] private float sprintSpeed = 10f;
        [SerializeField] private PlayerState playerState = PlayerState.Walking;
        private float _moveSpeed;
        private bool _isSprinting;
        private bool _isCrouching;
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
        [SerializeField] private float crouchScale = 0.5f;
        

        [Header("Jumping")] 
        [SerializeField] private float jumpForce = 5f;

        private InputManager _inputManager;

        private Rigidbody _rb;
        private float _startScaleY;
        private float _startPlayerHeight;

        [SerializeField] private bool canBeKilled;

        private PlayerAnimation playerAnimation;
        // Start is called before the first frame update
        void Start()
        {
            _inputManager = InputManager.Instance;
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
            playerAnimation = GetComponent<PlayerAnimation>();
            _inputManager.OnStartJump += Jump;
            _inputManager.OnSprint += Sprint;
            _inputManager.OnCrouch += Crouch;
            _startScaleY = transform.localScale.y;
            _startPlayerHeight = playerHeight;
        }

        private void OnDestroy()
        {
            _inputManager.OnStartJump -= Jump;
            _inputManager.OnSprint -= Sprint;
            _inputManager.OnCrouch -= Crouch;
        }


        // Update is called once per frame
        void Update()
        {
            StateHandler();
            CheckGrounded();
            MovementDirection();
            RigidbodyDrag();
        }

        private void RigidbodyDrag()
        {
            if (_isGrounded) _rb.drag = groundDrag;
            else _rb.drag = airDrag;
        }

        private void MovementDirection()
        {
            var transform1 = orientation;
            
            _moveDirection = transform1.forward * _inputManager.MovementInput.y +
                             transform1.right * _inputManager.MovementInput.x;
            
            _slopeMoveDirection = Vector3.ProjectOnPlane(_moveDirection, _slopeHit.normal);
        }

        private void CheckGrounded()
        {
            _isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, playerHeight / 2, 0), groundDistance,
                groundMask);
        }

        private void StateHandler()
        {
            if (_isGrounded && !_isSprinting && !_isCrouching)
            {
                playerState = PlayerState.Walking;
                _moveSpeed = walkSpeed;
            }

            if (_isGrounded && _isSprinting && !_isCrouching)
            {
                playerState = PlayerState.Sprinting;
                _moveSpeed = sprintSpeed;
            }

            if (_isGrounded && _isCrouching && !_isSprinting)
            {
                playerState = PlayerState.Crouching;
                _moveSpeed = crouchSpeed;
            }
                

            if (!_isGrounded) playerState = PlayerState.Jumping;

            if(_isGrounded && !_isSprinting && !_isCrouching && _rb.velocity.magnitude < 1)
            {
                playerState = PlayerState.Idle;
            }
            playerAnimation.UpdateAnimation(playerState);
        }

        private void Jump()
        {
            if (_isGrounded)
            {
                _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            }
        }

        private void Sprint(bool cancelled)
        {
            _isSprinting = !cancelled;
        }
        
        private void Crouch(bool canceled)
        {
            var localScale = transform.localScale;
            _isCrouching = !canceled;
            if (_isCrouching)
            {
                
                var newLocalScale = new Vector3(localScale.x, crouchScale, localScale.z);
                transform.localScale = newLocalScale;
                _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
                playerHeight *= crouchScale;
            }
            else
            {
                var newLocalScale = new Vector3(localScale.x, _startScaleY, localScale.z);
                transform.localScale = newLocalScale;
                playerHeight = _startPlayerHeight;
            }
            
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
            if(_isGrounded && !OnSlope()) _rb.AddForce(_moveDirection.normalized * (_moveSpeed * _movementMultiplier), ForceMode.Acceleration);
            else if(_isGrounded && OnSlope()) _rb.AddForce(_slopeMoveDirection.normalized * (_moveSpeed * _movementMultiplier), ForceMode.Acceleration);
            else _rb.AddForce(_moveDirection.normalized * (_moveSpeed * _movementMultiplier * _airMovementMultiplier), ForceMode.Acceleration);
            
        }

    }
    public enum PlayerState
    {
        Walking,
        Sprinting,
        Jumping,
        Idle,
        Crouching
    }
}

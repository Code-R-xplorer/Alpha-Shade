using System;
using UnityEngine;
using UnityEngine.Serialization;
using Utilities;

namespace Player
{
    public class Motion : MonoBehaviour, IDisplayText
    {
        [SerializeField] private float walkSpeed;
        [SerializeField] private float sprintSpeed;

        [SerializeField] private float playerHeight = 2;
        [SerializeField] private float groundDistance = 0.4f;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float jumpForce = 10f;
        
        private CameraManager _cameraManager;
        private float speed;
        private InputManager _input;

        private Rigidbody _rb;

        private const float SpeedMultiplier = 100f;

        private bool _isSprinting;

        private bool _isGrounded;

        private float _height;
        private CapsuleCollider _capsuleCollider;

        private float _totalStamina;
        [SerializeField] private float maxStamina, staminaDecreaseRate, staminaRegenRate;
        private bool _staminaDepleted;

        // Start is called before the first frame update
        void Start()
        {
            _input = InputManager.Instance;
            _capsuleCollider = GetComponent<CapsuleCollider>();
            _cameraManager = GetComponent<CameraManager>();
            _height = _capsuleCollider.height;
            _rb = GetComponent<Rigidbody>();
            _input.OnSprint += Sprint;
            _input.OnStartJump += Jump;
            _input.OnCrouch += Crouch;
            sprintSpeed *= SpeedMultiplier;
            walkSpeed *= SpeedMultiplier;
            jumpForce *= SpeedMultiplier;
            _totalStamina = maxStamina;
        }
        

        // Update is called once per frame
        void FixedUpdate()
        {
            float hMove = _input.MovementInput.x;
            float vMove = _input.MovementInput.y;
            CheckGrounded();

            Vector3 direction = new Vector3(hMove, 0, vMove);
            direction.Normalize();
            
            if (_rb.velocity.magnitude >= 0.2 & _isSprinting && !_staminaDepleted)
            {
                if (_totalStamina > 0f)
                {
                    speed = sprintSpeed;
                    _totalStamina -= staminaDecreaseRate * Time.deltaTime;
                }
                else
                {
                    _totalStamina = 0f;
                    _staminaDepleted = true;
                }
            }
            else
            {
                speed = walkSpeed;
                _isSprinting = false;
                if (_totalStamina < maxStamina)
                {
                    _totalStamina += staminaRegenRate * Time.deltaTime;
                }
                else
                {
                    _totalStamina = maxStamina;
                    _staminaDepleted = false;
                }
            }

            Vector3 targetVelocity = transform.TransformDirection(direction) * (speed * Time.deltaTime);
            targetVelocity.y = _rb.velocity.y;
            _rb.velocity = targetVelocity;
        }
        
        private void CheckGrounded()
        {
            _isGrounded = Physics.CheckSphere(transform.position - new Vector3(0, playerHeight / 2, 0), groundDistance,
                groundMask);
        }

        private void Sprint(bool canceled)
        {
            if (_staminaDepleted)
            {
                _isSprinting = false;
                return;
            }
            _isSprinting = !canceled;
        }
        
        private void Jump()
        {
            if (_isGrounded)
            {
                _rb.AddForce(transform.up * jumpForce);
            }
        }

        private void Crouch(bool canceled)
        {
            if (!canceled)
            {
                _cameraManager.SwitchCameraPosition(1);
                _capsuleCollider.height = _height * 0.5f;
                _rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
            }
            else
            {
                _cameraManager.SwitchCameraPosition(0);
                _capsuleCollider.height = _height;
            }
        }

        public string GetDisplayText()
        {
            return $"Stamina: {(int)_totalStamina}";
        }
    }
}

using System;
using Guards;
using UI;
using UnityEngine;
using Utilities;

namespace Player
{
    public class Melee : MonoBehaviour
    {
        private InputManager _inputManager;
        private LayerMask _layerMask;
        [SerializeField] private float attackRange = 1;
        [SerializeField] private float takedownMinTime = 2f;
        [SerializeField] private float damageDealt = 10f;
        // [SerializeField] private Transform hand;
        private float _startTakedownTime;
        private bool _performingTakedown;
        private bool _checkForTakeDown;

        private bool _canMelee;

        private GuardController _guardController;
        
        // Start is called before the first frame update
        void Start()
        {
            _inputManager = InputManager.Instance;
            _inputManager.OnMelee += PerformMelee;
            _layerMask = LayerMask.GetMask("Guard");
        }

        private void PerformMelee(bool cancelled, double duration)
        {
            // RaycastHit[] hits;
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            // hits = Physics.RaycastAll(ray, attackRange);
            // Debug.DrawRay(ray.origin, ray.direction, Color.blue, 5f);
            if (Physics.Raycast(ray, out hit, attackRange, _layerMask))
            {
                if (!cancelled)
                {
                    _startTakedownTime = Time.time;
                    _checkForTakeDown = true;
                    _performingTakedown = false;
                }
                if (cancelled)
                {
                    Debug.Log(duration);
                    if (hit.collider.CompareTag("GuardBack"))
                    {
                        
                        if (duration >= takedownMinTime)
                        {
                            _performingTakedown = false;
                            _checkForTakeDown = false;
                            PerformTakeDown();
                        }
                        else if(_canMelee)
                        {
                            _checkForTakeDown = false;
                            _performingTakedown = false;
                            DealMeleeDamage();
                        }
                    }
                    else if (_canMelee)
                    {
                        _performingTakedown = false;
                        _checkForTakeDown = false;
                        DealMeleeDamage();
                    }
                    _checkForTakeDown = false;
                    _performingTakedown = false;
                }
            }
            
        }

        // Update is called once per frame
        void Update()
        {
            if (_checkForTakeDown)
            {
                float timeRemaining = Time.time - _startTakedownTime;
                if (timeRemaining > 0.1f)
                {
                    _performingTakedown = true;
                    _checkForTakeDown = false;
                }
            }
        }

        private void DealMeleeDamage()
        {
            _guardController.GetComponent<IDamageable>().TakeDamage(damageDealt);
        }

        private void PerformTakeDown()
        {
            _guardController.TakeDown();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Guard))
            {
                _guardController = other.GetComponent<GuardController>();
                _canMelee = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag(Tags.Guard))
            {
                _canMelee = true;
                if (_performingTakedown)
                {
                    _guardController.HoldGuard();
                }
                else
                {
                    _guardController.FreeGuard();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.Guard))
            {
                _canMelee = false;
            }
        }

        private void OnDestroy()
        {
            _inputManager.OnMelee -= PerformMelee;
        }
    }
}

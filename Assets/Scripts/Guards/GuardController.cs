using System;
using System.Collections;
using Managers;
using Player;
using TheKiwiCoder;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Guards
{
    public class GuardController : MonoBehaviour, IDamageable
    {
        private BehaviourTreeRunner _behaviourTreeRunner;

        private GameObject _player;

        [SerializeField] private float hearingDistance = 5f;

        protected Blackboard blackboard;

        [SerializeField] private float health = 100;
        private bool _dead;

        private GuardVision _guardVision;
        private NavMeshAgent _navMeshAgent;
        private Rigidbody _rigidbody;

        private bool _deathSequence;

        private float _agentSpeed;

        [SerializeField] private float damageAmount = 15f;
        [SerializeField] private float damageRate = 0.5f;

        [SerializeField] private GunController gunController;
        private Animation _animation;

        private bool _dealingDamage;
        private bool _canDamage;

        private PlayerHealth _playerHealth;

        public bool stunned;

        public AccessLevel accessLevel = AccessLevel.Default;

        public bool guardActive;

        private void Awake()
        {
            _animation = GetComponent<Animation>();
            _animation.gun = gunController;
            gunController._animation = _animation;
        }

        public virtual void Initialize()
        {
            _behaviourTreeRunner = GetComponent<BehaviourTreeRunner>();
            _guardVision = GetComponentInChildren<GuardVision>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _rigidbody = GetComponent<Rigidbody>();
            _player = GameObject.FindWithTag("Player");
            blackboard = _behaviourTreeRunner.tree.blackboard;
            GameEvents.Instance.OnHeardSomething += Investigate;
            _agentSpeed = _navMeshAgent.speed;
            _playerHealth = _player.GetComponent<PlayerHealth>();
            guardActive = true;
            blackboard.materialChanger = GetComponentInChildren<MaterialChanger>();
        }

        public void CanSeePlayer(bool canSeePlayer)
        {
            if (canSeePlayer)
            {
                blackboard.playerPosition = _player.transform.position; 
                gunController.ShowGun();
            }
            blackboard.canSeePlayer = canSeePlayer;
        }

        private void Investigate(Transform investigateTransform, bool investigate)
        {
            if (investigate)
            {
                NavMeshPath path = new NavMeshPath();
                NavMesh.CalculatePath(transform.position,
                    investigateTransform.position, NavMesh.AllAreas, path);
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    float pathLength = Utils.CalculatePathLength(path);
                    if (pathLength <= hearingDistance)
                    {
                        blackboard.investigatePosition = investigateTransform.position;
                        blackboard.investigate = true;
                        return;
                    }
                }

            }

            blackboard.investigate = false;
        }

        public bool Investigating()
        {
            return blackboard.investigate;
        }

        public void TriggerHear(Transform target)
        {
            if (blackboard.investigate) return;
            NavMeshPath path = new NavMeshPath();
            NavMesh.CalculatePath(transform.position,
                target.position, NavMesh.AllAreas, path);
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                float pathLength = Utils.CalculatePathLength(path);
                if (pathLength <= hearingDistance)
                {
                    blackboard.investigatePosition = target.position;
                    blackboard.investigate = true;
                    return;
                }
            }
            blackboard.investigate = false;
        }

        private void Update()
        {
            if (_dead)
            {
                Destroy(gameObject);
                // if (!_deathSequence) StartCoroutine(DeathSequence());
            }

            if (stunned)
            {
                HoldGuard();
            }
            _animation.ChangeMasterState(blackboard.playerInRange ? Animation.MasterState.Weapon : Animation.MasterState.Normal);
            gunController.fire = blackboard.playerInRange;
        }

        private IEnumerator DeathSequence()
        {
            _deathSequence = true;
            _behaviourTreeRunner.enabled = false;
            _guardVision.enabled = false;
            _navMeshAgent.enabled = false;
            _rigidbody.AddForce(Vector3.forward * 2f, ForceMode.Impulse);
            yield return new WaitForSeconds(5f);
            Destroy(gameObject);

        }
        public void TakeDamage(float damage)
        {
            _guardVision.canSeePlayer = true;
            health -= damage;
            _dead = health <= 0;
        }

        public void TakeDown()
        {
            _dead = true;
        }

        public void HoldGuard()
        {
            if (_dead) return;
            _navMeshAgent.speed = 0;
            _navMeshAgent.isStopped = true;
        }

        public void FreeGuard()
        {
            if (_dead) return;
            _navMeshAgent.speed = _agentSpeed;
            _navMeshAgent.isStopped = false;
        }

        public void Stun(float duration)
        {
            StartCoroutine(StunRoutine(duration));
        }

        private IEnumerator StunRoutine(float duration)
        {
            stunned = true;
            blackboard.stunned = true;
            Debug.Log(duration);
            yield return new WaitForSeconds(duration);
            stunned = false;
            blackboard.stunned = false;
            FreeGuard();
        }

        private void OnDestroy()
        {
            GameEvents.Instance.OnHeardSomething -= Investigate;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Player))
            {
                _canDamage = true;
                // StartCoroutine(DealDamage());
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Player))
            {
                _canDamage = true;
                // StartCoroutine(DealDamage());
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Player))
            {
                _canDamage = false;
            }
        }

        // private IEnumerator DealDamage()
        // {
        //     if(_dealingDamage) yield break;
        //     _dealingDamage = true;
        //     yield return new WaitForSeconds(damageRate);
        //     if(_canDamage) _playerHealth.DecreaseHealth(damageAmount);
        //     _dealingDamage = false;
        // }
    }
}
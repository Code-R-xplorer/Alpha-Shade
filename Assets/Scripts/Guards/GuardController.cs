using System;
using System.Collections;
using Player;
using TheKiwiCoder;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Guards
{
    public class GuardController : MonoBehaviour
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

        private bool _dealingDamage;
        private bool _canDamage;

        private PlayerHealth _playerHealth;

        protected virtual void Start()
        {
            _behaviourTreeRunner = GetComponent<BehaviourTreeRunner>();
            _guardVision = GetComponentInChildren<GuardVision>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _rigidbody = GetComponent<Rigidbody>();
            _player = GameObject.FindWithTag("Player");
            blackboard = _behaviourTreeRunner.tree.blackboard;
            GameEvents.Instance.OnHeardSomething += Investigate;
            _agentSpeed = _navMeshAgent.speed;
            _playerHealth = _player.transform.parent.GetComponent<PlayerHealth>();
        }

        public void CanSeePlayer(bool canSeePlayer)
        {
            if (canSeePlayer) blackboard.playerPosition = _player.transform.position;
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

        private void Update()
        {
            if (_dead)
            {
                if (!_deathSequence) StartCoroutine(DeathSequence());
            }
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

        public void DecreaseHealth(float damage)
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

        private void OnDestroy()
        {
            GameEvents.Instance.OnHeardSomething -= Investigate;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Player))
            {
                _canDamage = true;
                StartCoroutine(DealDamage());
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Player))
            {
                _canDamage = true;
                StartCoroutine(DealDamage());
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.collider.CompareTag(Tags.Player))
            {
                _canDamage = false;
            }
        }

        private IEnumerator DealDamage()
        {
            if(_dealingDamage) yield break;
            _dealingDamage = true;
            yield return new WaitForSeconds(damageRate);
            if(_canDamage) _playerHealth.DecreaseHealth(damageAmount);
            _dealingDamage = false;
        }
    }
}
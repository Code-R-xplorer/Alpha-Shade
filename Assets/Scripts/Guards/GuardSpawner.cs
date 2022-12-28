using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Utilities;

namespace Guards
{
    public class GuardSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject guardPrefab;

        [SerializeField] private int amount = 1;
        [SerializeField] private float spawnDelay = 5f;

        [SerializeField] private List<Transform> patrolPoints;

        private int _spawnedGuards;
        // Start is called before the first frame update
        void Start()
        {
            GameEvents.Instance.OnInitiateGuards += SpawnGuard;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var transform1 = transform;
            var position = transform1.position;
            Gizmos.DrawSphere(position, 0.25f);
            Gizmos.DrawRay(position, transform1.forward * 2);
        }

        private void SpawnGuard()
        {
            StartCoroutine(SpawnGuardDelay());
        }

        private IEnumerator SpawnGuardDelay()
        {
            yield return new WaitForSeconds(spawnDelay);
            var transform1 = transform;
            _spawnedGuards++;
            float guardHeight = guardPrefab.GetComponent<NavMeshAgent>().height / 2;
            Vector3 spawnPos = new Vector3(transform1.position.x, transform1.position.y + guardHeight,
                transform1.position.z);
            GameObject guard = Instantiate(guardPrefab, spawnPos, transform1.rotation);
            PatrolGuard patrolGuard = guard.GetComponent<PatrolGuard>();
            if (patrolGuard)
            {
                patrolGuard.SetPatrolPoints(patrolPoints);
            }

            if (_spawnedGuards < amount) StartCoroutine(SpawnGuardDelay());
        }
    }
}

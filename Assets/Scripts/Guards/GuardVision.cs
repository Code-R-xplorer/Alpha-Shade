using UnityEngine;
using UnityEngine.Serialization;

namespace Guards
{
    public class GuardVision : MonoBehaviour
    {
        [SerializeField] private Transform guardEyes;
        [SerializeField] private Collider eyesCollider;
        [SerializeField] private Vector3 rightTarget = new Vector3(0, 40, 0);
        [SerializeField] private Vector3 leftTarget = new Vector3(0, -40, 0);
        [SerializeField] private float lookSpeed = 3;
        [SerializeField] private Vector3 playerEyeOffset;
        
        private bool _lookedLeftRight = false; // false = left, true = right
        public bool canLookLeftRight = true;
        [FormerlySerializedAs("_player")] [SerializeField] private GameObject player;
        private GuardController _guardController;
        private Transform _startingTransform;

        [SerializeField] private bool canSeePlayer;

        private LayerMask _layerMask;

        
        private void Start() 
        {
            _guardController = GetComponentInParent<GuardController>();
            _startingTransform = transform;
            _layerMask = LayerMask.GetMask("Guard");
            _layerMask = ~_layerMask;
        }
        private void Update() 
        {
            if(canLookLeftRight)
            {
                if(!_lookedLeftRight)
                {
                    eyesCollider.transform.localRotation = Quaternion.Lerp(eyesCollider.transform.localRotation,Quaternion.Euler(leftTarget), lookSpeed*Time.deltaTime);
                    if(eyesCollider.transform.localRotation == Quaternion.Euler(leftTarget))
                    {
                        _lookedLeftRight = true;
                    }
                }
                else
                {
                    eyesCollider.transform.localRotation = Quaternion.Lerp(eyesCollider.transform.localRotation,Quaternion.Euler(rightTarget), lookSpeed*Time.deltaTime);
                    if(eyesCollider.transform.localRotation == Quaternion.Euler(rightTarget))
                    {
                        _lookedLeftRight = false;
                    }
                }
            }
            if(canSeePlayer)
            {
                transform.LookAt(player.transform.position + playerEyeOffset);
                
            }

            if (!canSeePlayer)
            {
                var transform1 = transform;
                transform1.position = _startingTransform.position;
                transform1.rotation = _startingTransform.rotation;
            }
            _guardController.CanSeePlayer(canSeePlayer);

        }

        // This function is called when something enters the guards view frustrum, a mesh collider used as the first stage in seeing the player.
        private void OnProcessViewFrustrum(Collider other)
        {
            canSeePlayer = CheckSightForPlayer(other.transform.position + playerEyeOffset);
        }



        // Performs a raycast to the center of the player to check for line of sight
        // May want to change this to do multiple casts at different points on the player
        public bool CheckSightForPlayer(Vector3 position)
        {
            // Debug.DrawRay(guardEyes.position, ((position - guardEyes.position).normalized) * 100f, Color.blue, 10f);
            if (Physics.Raycast(guardEyes.position, (position - guardEyes.position).normalized, out var info, 100000f, _layerMask)) // Can the guard see something in between him and the player transform?
            {
                Debug.Log(info.collider.tag);
                return info.collider.CompareTag("Player");
            }
            return false;
        }



        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("GuardVision Trigger Enter");
            OnProcessViewFrustrum(other);
        }

        private void OnTriggerStay(Collider other)
        {
            OnProcessViewFrustrum(other);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                canSeePlayer = false;
            }
        }
    }
}

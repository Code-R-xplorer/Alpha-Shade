using UnityEngine;
using Utilities;

namespace Player
{
    public class Motion : MonoBehaviour
    {
        [SerializeField] private float speed;
        private InputManager _input;

        private Rigidbody _rb;
        // Start is called before the first frame update
        void Start()
        {
            _input = InputManager.Instance;
            _rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float hMove = _input.MovementInput.x;
            float vMove = _input.MovementInput.y;

            Vector3 direction = new Vector3(hMove, 0, vMove);
            direction.Normalize();

            _rb.velocity = transform.TransformDirection(direction) * (speed * Time.deltaTime);

        }
    }
}

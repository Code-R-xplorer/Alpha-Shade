using UnityEngine;
using Utilities;

namespace Player
{
    public class PocketWatch : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");
        private static readonly int ToggleLeft = Animator.StringToHash("Toggle_Left");
        private static readonly int ToggleRight = Animator.StringToHash("Toggle_Right");

        private bool _watchShown;
        private bool _animPlaying;
        private InputManager _inputManager;

        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(Close, -1, 0.0f);
            _inputManager = InputManager.Instance;
            _inputManager.OnStartToggleWatch += ToggleWatch;
            _inputManager.OnStartToggleWatchScreenL += ToggleScreenL;
            _inputManager.OnStartToggleWatchScreenR += ToggleScreenR;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void ToggleWatch()
        {
            if (_animPlaying) return;
            if (_watchShown)
            {
                _animator.Play(Close, -1, 0.0f);
                _watchShown = false;
            }
            else
            {
                _animator.Play(Open, -1, 0.0f);
                _watchShown = true;
            }
        }

        private void ToggleScreenL()
        {
            _animator.Play(ToggleLeft, -1, 0.0f);
        }

        private void ToggleScreenR()
        {
            _animator.Play(ToggleRight, -1, 0.0f);
        }

        public void AnimationStart()
        {
            _animPlaying = true;
        }

        public void AnimationFinished()
        {
            _animPlaying = false;
        }

        public void ToggleMesh(int show)
        {
            if (show == 0)
            {
                transform.GetChild(0).gameObject.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(false);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            
            
        }
    }
}

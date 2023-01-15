using System;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using UI.Pocket_Watch;

namespace Player
{
    public class PocketWatch : MonoBehaviour
    {
        private Animator _animator;

        private static readonly int Open = Animator.StringToHash("Open");
        private static readonly int Close = Animator.StringToHash("Close");
        private static readonly int ToggleScreen = Animator.StringToHash("Toggle_Screen");
        private static readonly int ToggleLeft = Animator.StringToHash("Toggle_Left");
        private static readonly int ToggleRight = Animator.StringToHash("Toggle_Right");

        private bool _watchShown;
        private bool _animPlaying;
        private bool _showScreen;
        private InputManager _inputManager;

        private int _screenIndex;

        [SerializeField] private List<BaseScreen> screens;

        private GameObject _screenParent;
        // Start is called before the first frame update
        void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.Play(Close, -1, 0.0f);
            _inputManager = InputManager.Instance;
            _inputManager.OnStartToggleWatch += ToggleWatch;
            _inputManager.OnStartToggleWatchScreen += ToggleWatchScreen;
            _inputManager.OnStartToggleWatchScreenL += ToggleScreenL;
            _inputManager.OnStartToggleWatchScreenR += ToggleScreenR;
            GameObject player = GameObject.FindWithTag(Tags.Player).transform.parent.gameObject;
            foreach (var screen in screens)
            {
                screen.Init(this, player);
            }
            _screenParent = transform.GetChild(2).gameObject;
            _screenParent.SetActive(false);
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
                if (_showScreen)
                {
                    _screenParent.SetActive(false);
                    _showScreen = false;
                }
                _animator.Play(Close, -1, 0.0f);
                _watchShown = false;
            }
            else
            {
                _animator.Play(Open, -1, 0.0f);
                _watchShown = true;
            }
        }
        
        private void ToggleWatchScreen()
        {
            if (_animPlaying) return;
            if (!_watchShown) return;
            _animator.Play(ToggleScreen, -1, 0.0f);
            _showScreen = !_showScreen;
            _screenParent.SetActive(_showScreen);
        }

        private void ToggleScreenL()
        {
            if (_animPlaying) return;
            _animator.Play(ToggleLeft, -1, 0.0f);
            _screenIndex--;
            if (_screenIndex < 0)
            {
                _screenIndex = screens.Count - 1;
            }
            ChangeScreen(_screenIndex);
        }

        private void ToggleScreenR()
        {
            if (_animPlaying) return;
            _animator.Play(ToggleRight, -1, 0.0f);
            _screenIndex++;
            if (_screenIndex > screens.Count - 1)
            {
                _screenIndex = 0;
            }
            ChangeScreen(_screenIndex);
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
        
        public event Action<int> OnChangeScreen;
        public void ChangeScreen(int index) { OnChangeScreen?.Invoke(index); }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class TakeDownBar : MonoBehaviour
    {
        
        private float _lerpingValue, _a, _b, _time, _duration;

        private bool _isLerping;

        private Image fill;
        private Slider slider;

        [SerializeField] private Color inProgress;
        [SerializeField] private Color failed;
        [SerializeField] private Color finished;
        
        
        // Start is called before the first frame update
        void Start()
        {
            fill = transform.GetChild(0).GetComponent<Image>();
            slider = GetComponent<Slider>();
            // fill.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isLerping)
            {
                // Accumulating time
                _time += Time.deltaTime;
 
                // determining where are we on the time line
                // flow is our time line increasing from 0 to 1
                float flow = _time / _duration;
 
                if (flow < 1)
                {
                    // lerping formula
                    _lerpingValue = _a + (_b - _a) * flow;
                    // var result = (Mathf.Round(_lerpingValue * 1000)) / 1000.0;
                    // _lerpingValue = (float)result;
                }
                else
                {
                    // operation is done
                    _lerpingValue = _b;
                    _isLerping = false;
                    fill.color = finished;
                    StartCoroutine(HideBar());
                }

                slider.value = _lerpingValue;
            }
        }
        
        
        public void StartProgressBar(float duration)
        {
            // fill.enabled = true;
            fill.color = inProgress;
            _a = 0f;
            _b = 1f;
            _duration = duration;
            _time = 0;
            _isLerping = true;

        }

        public void ProgressFailed()
        {
            _isLerping = false;
            fill.color = failed;
            StartCoroutine(HideBar());
        }

        private IEnumerator HideBar()
        {
            Debug.Log("HideBar");
            yield return new WaitForSeconds(2f);
            // fill.enabled = false;
            // barParent.SetActive(false);
        }
        
        
    }
}

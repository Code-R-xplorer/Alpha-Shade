using UnityEngine;
using UnityEngine.UI;

namespace Tasks.PC_Task
{
    public class FileExplorer : MonoBehaviour
    {
        [SerializeField] private int objectiveID;
        [SerializeField] private float downloadTime;
        [SerializeField] private GameObject downloadFailed;
        [SerializeField] private GameObject downloadComplete;
        [SerializeField] private GameObject downloading;
        [SerializeField] private GameObject file;
        [SerializeField] private Image bar;
        [SerializeField] private bool downloadFail;
        private bool _isLerping;
        private float _time, _duration, _lerpingValue, _a, _b;


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
                }
                else
                {
                    // operation is done
                    _lerpingValue = _b;
                    _isLerping = false;
                    downloading.SetActive(false);
                    downloadComplete.SetActive(true);
                    transform.parent.GetComponent<PC>().CompleteObjective(objectiveID);
                }

                if (downloadFail && _lerpingValue >= 0.9)
                {
                    _isLerping = false;
                    downloading.SetActive(false);
                    downloadFailed.SetActive(true);
                    transform.parent.GetComponent<PC>().CompleteObjective(objectiveID);
                }
            }

            bar.fillAmount = _lerpingValue;
        }

        public void StartTimer(float duration)
        {
            _a = 0;
            _b = 1;
            _duration = duration;
            _time = 0;
            _isLerping = true;
        }

        public void ShowDownloading()
        {
            file.SetActive(false);
            downloading.SetActive(true);
            StartTimer(downloadTime);
        }
    }
}
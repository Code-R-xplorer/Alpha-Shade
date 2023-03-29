using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FPSCounter(30);
    }

    private void FPSCounter(int frameCheck)
    {
        if (Time.frameCount % frameCheck == 0)
        {
            var fps = (int) (1f / Time.unscaledDeltaTime);
            fpsText.text = $"FPS: {fps}";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCount : MonoBehaviour
{
    private float fps;
    [SerializeField] private Text fpsText;

    void Update()
    {
        fps = 1.0f / Time.deltaTime;
        fpsText.text = $"fps: {(int)fps}";
    }
}

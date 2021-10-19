using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeElapsedManager : MonoSingleton<TimeElapsedManager>
{
    [SerializeField] private AudioClip song        = null; // 곡
                     public  float     songIternalLength;  // 곡의 길이
                     public  float     bpm;                // 곡의 BPM
                     private float     currentTime = 0.0f; // 현제 시간

    private void Awake()
    {
        songIternalLength = song.length;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }



    public float GetCurrentTime()
    {
        return currentTime;
    }

}

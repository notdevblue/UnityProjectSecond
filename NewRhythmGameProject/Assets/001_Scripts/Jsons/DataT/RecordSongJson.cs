using System;
using UnityEngine;


[Serializable]
public class RecordSongJson
{
    public AudioClip song;
    public float bpm;

    public void Add(AudioClip song)
    {
        this.song = song;
    }

    public void Add(float bpm)
    {
        this.bpm = bpm;
    }
}

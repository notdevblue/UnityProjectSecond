using System;
using UnityEngine;


[Serializable]
public class RecordSongJson
{
    public AudioClip song;

    public void Add(AudioClip song)
    {
        this.song = song;
    }
}

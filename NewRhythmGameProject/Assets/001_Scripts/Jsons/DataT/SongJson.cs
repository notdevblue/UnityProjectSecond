using System;
using UnityEngine;

[Serializable]
public class SongJson : JsonObject
{
    public string[] levels = new string[3];
    public string ingameinfo;
    public string titleinfo;
    public AudioClip song;
}

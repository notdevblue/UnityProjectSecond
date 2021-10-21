using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public AudioSource noteSound;
    public AudioSource song;

    NoteJson noteData = new NoteJson();

    int firstIdx = 0;
    int secondIdx = 0;
    int thirdIdx = 0;

    float curTime = 0.0f;

    private void Start()
    {
        noteData.OverrideData(SongLoader.songJson);
        song.Play();
    }

    private void Update() {
        curTime += Time.deltaTime;

        if(curTime >= noteData.firstLineNote[firstIdx] && firstIdx < noteData.firstLineNote.Count - 1)
        {
            noteSound.Play();
            Debug.Log("F");
            ++firstIdx;
        }
        if (curTime >= noteData.secondLineNote[secondIdx] && secondIdx < noteData.secondLineNote.Count - 1)
        {
            noteSound.Play();
            Debug.Log("S");
            ++secondIdx;
        }
        if (curTime >= noteData.thirdLineNote[thirdIdx] && thirdIdx < noteData.thirdLineNote.Count - 1)
        {
            noteSound.Play();
            Debug.Log("T");
            ++thirdIdx;
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public AudioSource audio;

    float curTime = 0.0f;

    private void Update() {
        curTime += Time.deltaTime;


        // TODO : 노트 출력 (지금은 사운드)
    }
}

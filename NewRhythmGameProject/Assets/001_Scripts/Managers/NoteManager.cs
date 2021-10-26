using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoSingleton<NoteManager>
{
    public AudioSource noteSoundSource;
    public AudioSource song;

    NoteJson noteData = new NoteJson();

    int firstIdx = 0;
    int secondIdx = 0;
    int thirdIdx = 0;


    int firstNoteIndex = 0;
    int secondNoteIndex = 0;
    int thirdNoteIndex = 0;

    public float CurrentTime { get; private set; }

    bool isPlaying = false;

    private void Start()
    {
        // 시간 초기화
        CurrentTime = 0.0f;

        // 곡 불러옴
        noteData = JsonUtility.FromJson<NoteJson>(SongLoader.Instance.GetSong(0).levels[1]); // TODO : 하드 코딩

        // 노래 넣음
        song.clip = SongLoader.Instance.GetSong(0).song;

        Invoke(nameof(Play), 1.5f);
    }

    private void Update() {

        if(!isPlaying) return;

        CurrentTime += Time.deltaTime;

#region 노트 스폰

        if (firstNoteIndex < noteData.firstLineNoteAppearTime.Count - 1 && CurrentTime >= noteData.firstLineNoteAppearTime[firstNoteIndex])
        {
#warning DEBUG CODE
            GameObject temp = NotePoolManager.Instance.Get();
            temp.transform.position = Vector2.up; // TODO : note position
            ++firstNoteIndex;
        }
        if (secondNoteIndex < noteData.secondLineNoteAppearTime.Count - 1 && CurrentTime >= noteData.secondLineNoteAppearTime[secondNoteIndex])
        {
#warning DEBUG CODE
            GameObject temp = NotePoolManager.Instance.Get();
            ++secondNoteIndex;
        }
        if (thirdNoteIndex < noteData.thirdLineNoteAppearTime.Count - 1 && CurrentTime >= noteData.thirdLineNoteAppearTime[thirdNoteIndex])
        {
#warning DEBUG CODE
            GameObject temp = NotePoolManager.Instance.Get();
            temp.transform.position = Vector2.down; // TODO : note position
            ++thirdNoteIndex;
        }

#endregion

#region 임시 판정?

        if(firstIdx < noteData.firstLineNote.Count - 1 && CurrentTime >= noteData.firstLineNote[firstIdx])
        {
            noteSoundSource.Play();
            Debug.Log("F");
            ++firstIdx;
        }
        if (secondIdx < noteData.secondLineNote.Count - 1 && CurrentTime >= noteData.secondLineNote[secondIdx])
        {
            noteSoundSource.Play();
            Debug.Log("S");
            ++secondIdx;
        }
        if (thirdIdx < noteData.thirdLineNote.Count - 1 && CurrentTime >= noteData.thirdLineNote[thirdIdx])
        {
            noteSoundSource.Play();
            Debug.Log("T");
            ++thirdIdx;
        }

#endregion

    }


    private void Play()
    {
        song.Play();

        isPlaying = true;
        CurrentTime   = 0;
    }


    /// <summary>
    /// 입력 판정
    /// </summary>
    public void CheckInput(int line)
    {
        switch(line)
        {
            case 1:
                if(CurrentTime < noteData.firstLineNote[firstIdx] + 0.1f && CurrentTime > noteData.firstLineNote[firstIdx] - 0.1f)
                {
                    Debug.Log("F Hit");
                }
                break;

            case 2:
                if(CurrentTime < noteData.secondLineNote[secondIdx] + 0.1f && CurrentTime > noteData.secondLineNote[secondIdx] - 0.1f)
                {
                    Debug.Log("S Hit");
                }
                break;

            case 3:
                if(CurrentTime < noteData.thirdLineNote[thirdIdx] + 0.1f && CurrentTime > noteData.thirdLineNote[thirdIdx] - 0.1f)
                {
                    Debug.Log("T Hit");
                }
                break;
        }
    }
}

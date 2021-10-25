using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToJson : MonoBehaviour
{
#warning DEBUG CODE
    public float BPM; #warning NULL
#warning DEBUG CODE
    private float quaterNote;

    NoteJson note = new NoteJson();
    RecordSongJson recordSong = new RecordSongJson();
    private AudioSource audioSource = null;

    float currentTime;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        quaterNote = BPM / 60.0f;
    }

    void Start()
    {
        currentTime = 0.0f;
        recordSong = SongLoader.Instance.GetRecordSong();
        
        if(recordSong == null) // NULL 체크
        {
            Debug.LogWarning("No Song Found.");
            enabled = false;
            return;
        }

        audioSource.clip = recordSong.song;
        audioSource.Play();

        // 노트 기록
        InputSystem.Instance.OnKeyFirstline  += () => {
            Debug.Log("First");
            note.firstLineNote.Add(currentTime);
            note.firstLineNoteAppearTime.Add(currentTime - quaterNote);
        };

        InputSystem.Instance.OnKeySecondline += () => {
            Debug.Log("Second");
            note.secondLineNote.Add(currentTime);
            note.secondLineNoteAppearTime.Add(currentTime - quaterNote);
        };

        InputSystem.Instance.OnKeyThirdline  += () => {
            Debug.Log("Third");
            note.thirdLineNote.Add(currentTime);
            note.thirdLineNoteAppearTime.Add(currentTime - quaterNote);
        };
    }

    private void Update()
    {
        currentTime += Time.deltaTime; // 시간 흐름

        if(Input.GetKeyDown(KeyCode.X)) // 찍은 노트 저장
        {
            JsonFileManager.Write("recordedData.json",
                                   JsonFileManager.Combine(".", "Songs", "RecordedData"),
                                   JsonUtility.ToJson(note));
            audioSource.Stop();
            Debug.Log("Saved");
        }
    }
}

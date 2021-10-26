using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputToJson : MonoSingleton<InputToJson>
{
    [SerializeField] private Text text = null;


#warning DEBUG CODE
    public float BPM = 113;
#warning DEBUG CODE
    private float sixteenthNote;

    NoteJson note = new NoteJson();
    RecordSongJson recordSong = new RecordSongJson();
    private AudioSource audioSource = null;

    float currentTime;

    public event Action OnRecordEnd;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sixteenthNote = BPM / 60.0f / 4.0f * 16.0f;
        OnRecordEnd += () => { };
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
#warning DEBUG CODE
            note.firstLineNoteAppearTime.Add(currentTime - sixteenthNote);
        };

        InputSystem.Instance.OnKeySecondline += () => {
            Debug.Log("Second");
            note.secondLineNote.Add(currentTime);
#warning DEBUG CODE
            note.secondLineNoteAppearTime.Add(currentTime - sixteenthNote);
        };

        InputSystem.Instance.OnKeyThirdline  += () => {
            Debug.Log("Third");
            note.thirdLineNote.Add(currentTime);
#warning DEBUG CODE
            note.thirdLineNoteAppearTime.Add(currentTime - sixteenthNote);
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
            text.text = "Saved.";
            Debug.Log("Saved");
        }
    }
}

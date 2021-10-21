using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputToJson : MonoBehaviour
{
    public AudioSource song;

    NoteJson note = new NoteJson();

    float currentTime;

    void Start()
    {
        song.Play();
        currentTime = 0.0f;

        // 노트 기록
        InputSystem.Instance.OnKeyFirstline  += () => {
            Debug.Log("First");
            note.firstLineNote.Add(currentTime);
        };

        InputSystem.Instance.OnKeySecondline += () => {
            Debug.Log("Second");
            note.secondLineNote.Add(currentTime);
        };

        InputSystem.Instance.OnKeyThirdline  += () => {
            Debug.Log("Third");
            note.thirdLineNote.Add(currentTime);
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

            song.Stop();
            Debug.Log("Saved");
        }
    }
}

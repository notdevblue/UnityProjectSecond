using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    void Start()
    {
        InputSystem.Instance.OnKeyFirstline += () => {
            NoteManager.Instance.CheckInput(1);
        };

        InputSystem.Instance.OnKeySecondline += () => {
            NoteManager.Instance.CheckInput(2);
        };

        InputSystem.Instance.OnKeyThirdline += () => {
            NoteManager.Instance.CheckInput(3);
        };

        // TODO : 판정
    }
}

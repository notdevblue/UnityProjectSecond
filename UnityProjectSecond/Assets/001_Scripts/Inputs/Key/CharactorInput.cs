using System;
using UnityEngine;

// 키 매핑용

public enum MouseInput
{
    Left = 0,
    Right,
    Wheel
}

[Serializable]
public class CharactorInput : JsonObject
{
    // 이동
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    public KeyCode jump = KeyCode.Space;
    public KeyCode atk = KeyCode.K;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;

    // 능력
    public KeyCode timeSwitch = KeyCode.LeftControl;

    // 자동 훅
    public KeyCode autoHook = KeyCode.E;
    public MouseInput autoHookMouse = MouseInput.Right;

    // 공격
    public MouseInput atkMouse = MouseInput.Left;
}

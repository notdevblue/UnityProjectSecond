using System;
using UnityEngine;

public enum MouseInput
{
    Left = 0,
    Right,
    Wheel
}

[Serializable]
public class CharactorInput : JsonObject
{
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    public KeyCode jump = KeyCode.Space;
    public KeyCode atk = KeyCode.K;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode timeSwitch = KeyCode.LeftControl;
    public MouseInput atkMouse = MouseInput.Left;
}

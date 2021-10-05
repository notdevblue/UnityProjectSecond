using System;
using UnityEngine;

public enum MouseInput
{
    Left = 0,
    Right,
    Wheel
}

[Serializable]
public class OptionInput : JsonObject
{
    public KeyCode right = KeyCode.D;
    public KeyCode left = KeyCode.A;
    public KeyCode jump = KeyCode.Space;
    public KeyCode atk = KeyCode.K;
}

using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class InputJson : JsonObject
{
    public List<KeyCode> firstLineInput  = new List<KeyCode>() { KeyCode.A, KeyCode.S, KeyCode.D};
    public List<KeyCode> secondLineInput = new List<KeyCode>() { KeyCode.Space };
    public List<KeyCode> thirdLineInput  = new List<KeyCode>() { KeyCode.J, KeyCode.K, KeyCode.L};
}

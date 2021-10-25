using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class InputJson : JsonObject
{
    public List<KeyCode> firstLineInput  = new List<KeyCode>() { KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F};
    public List<KeyCode> secondLineInput = new List<KeyCode>() { KeyCode.Space, KeyCode.LeftAlt, KeyCode.RightAlt };
    public List<KeyCode> thirdLineInput  = new List<KeyCode>() { KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Colon};
}

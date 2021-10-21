using System;
using System.Collections.Generic;

// 노트 데이터 저장 클레스

[Serializable]
public class NoteJson : JsonObject
{
    public List<float> firstLineNote      = new List<float>();
    public List<float> firstLineLongNote  = new List<float>();
    public List<float> secondLineNote     = new List<float>();
    public List<float> secondLineLongNote = new List<float>();
    public List<float> thirdLineNote      = new List<float>();
    public List<float> thirdLineLongNote  = new List<float>();
}

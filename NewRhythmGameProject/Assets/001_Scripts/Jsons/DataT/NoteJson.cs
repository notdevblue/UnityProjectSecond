using System;
using System.Collections.Generic;

// 노트 데이터 저장 클레스

[Serializable]
public class NoteJson : JsonObject
{
    public List<float> firstLineNote            = new List<float>(); // 판정
    public List<float> firstLineNoteAppearTime  = new List<float>(); // 노트 나오는 시간
    public List<float> secondLineNote           = new List<float>(); // 판정
    public List<float> secondLineNoteAppearTime = new List<float>(); // 노트 나오는 시간
    public List<float> thirdLineNote            = new List<float>(); // 판정
    public List<float> thirdLineNoteAppearTime  = new List<float>(); // 노트 나오는 시간
}

using System;
using System.Collections.Generic;

// 노트 데이터 저장 클레스

[Serializable]
public class NoteJson : JsonObject
{
    public List<double> firstLineNote;
    public List<double> firstLineLongNote;
    public List<double> secondLineNote;
    public List<double> secondLineLongNote;
    public List<double> thirdLineNote;
    public List<double> thirdLineLongNote;
}

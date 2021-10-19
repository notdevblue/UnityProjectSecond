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

    // public NoteJson(List<double> firstLineNote,  List<double> firstLineLongNote,
    //                 List<double> secondLineNote, List<double> secondLineLongNote,
    //                 List<double> thirdLineNote,  List<double> thirdLineLongNote) {
        
    //     this.firstLineNote      = firstLineNote;
    //     this.firstLineLongNote  = firstLineLongNote;
    //     this.secondLineNote     = secondLineNote;
    //     this.secondLineLongNote = secondLineLongNote;
    //     this.thirdLineNote      = thirdLineNote;
    //     this.thirdLineLongNote  = thirdLineLongNote;
    // }

}

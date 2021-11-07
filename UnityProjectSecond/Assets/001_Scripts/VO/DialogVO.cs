using System;
using System.Collections.Generic;

// Dialogs 의 요소

[Serializable]
public class DialogVO
{
    public int id;
    public List<ScriptVO> script;
}

// 실제 대사

[Serializable]
public class ScriptVO
{
    public int icon;
    public string text;
}
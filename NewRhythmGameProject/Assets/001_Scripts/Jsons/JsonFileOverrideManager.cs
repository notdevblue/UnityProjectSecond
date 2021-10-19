using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonFileOverrideManager : MonoSingleton<JsonFileOverrideManager>
{
    
#if UNITY_EDITOR
    public bool createNewJson = false;
#endif // 저장된 파일 삭제 후 재생성 여부

    InputJson inputs = new InputJson();
    NoteJson notes = new NoteJson(); // TODO : 곡 수에 따라 늘려야 함

    private void Awake()
    {
        #region 파일 삭제 여부 확인 ( 에디터에서만 동작함 )
        
#if UNITY_EDITOR
        if (createNewJson)
        {
            createNewJson = UnityEditor.EditorUtility.DisplayDialog("경고", "존재하는 JSON 파일을 삭제 후 재생성하려고 합니다.\r\n진행할까요?", "예", "아니요");
        }
#endif
        #endregion

        SetJsonData(inputs);
        SetJsonData(notes);
    }

    /// <summary>
    /// JSON 을 읽고 Override 함
    /// </summary>
    /// <param name="obj">Override 할 Class</param>
    private void SetJsonData<T>(T obj) where T : JsonObject
    {
        string data = JsonFileManager.Read(obj.GetType().ToString());

    if(
#region 파일 삭제 후 재생성 여부 ( 에디터에서만 동작함 )
#if UNITY_EDITOR
        createNewJson ||
#endif
#endregion
        data == null)
        {
            JsonFileManager.Write(obj.GetType().ToString(), obj.ToString());
            data = JsonFileManager.Read(obj.GetType().ToString());
        }

        Debug.Log($"Loaded: {data} as {obj.GetType()}");
        obj.OverrideData(data);
    }


}

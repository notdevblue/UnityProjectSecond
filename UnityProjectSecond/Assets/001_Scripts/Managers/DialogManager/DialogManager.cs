using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoSingleton<DialogManager>
{
    [Header("0 = 플레이어, 1 = 슬라임")]
    [SerializeField] private List<Sprite> iconList = new List<Sprite>();


    // 스크립트 저장 용
    private Dictionary<int, DialogVO> dialogDict = new Dictionary<int, DialogVO>();

    private int currentDialogId = -1;
    private int currentIdx = -1;
    private DialogVO currentDialog = null;

    private void Awake()
    {
        // 이야...
        JsonUtility.FromJson<ScriptsVO>(
            (Resources.Load("DialogJson/Dialog") as TextAsset)
            .ToString())
                   .dialogs
                   .ForEach(e =>
                        dialogDict.Add(e.id, e)
        );
    }

    private void Update()
    {
        if(DialogInstance.Instance.IsOpen && Input.GetKeyDown(KeyCode.Space))
        {
            NextScript();
        }
    }

    /// <summary>
    /// 해당하는 ID의 다이얼로그를 보여줍니다.
    /// </summary>
    /// <param name="id">해당하는 다이얼로그의 id<br/>-1 인 경우 다이얼로그 로드 안함</param>
    public void Show(int id = -1, System.Action action = null)
    {
        if(id != -1)
        {
            currentDialog = GetDialog(id);
        }

        if (currentDialog == null) return;

        Sprite icon = iconList[currentDialog.script[currentIdx].icon];
        string text = currentDialog.script[currentIdx].text;
        string name = currentDialog.script[currentIdx].name;

        DialogInstance.Instance.Show(text, name, icon, action);
    }

    /// <summary>
    /// 다음 대사를 불러옵니다.<br/>더 이상 대사가 없다면 알아서 닫아줌.
    /// </summary>
    public void NextScript()
    {
        ++currentIdx;
        if (!TextLeft())
        {
            DialogInstance.Instance.Close();
        }
        else
        {
            Show();
        }
    }


    /// <summary>
    /// 해당하는 ID 의 ScriptVO 를 반환합니다.
    /// </summary>
    /// <param name="id">해당하는 다이얼로그의 id</param>
    /// <returns>해당하는 다이얼로그의 id</returns>
    private DialogVO GetDialog(int id)
    {
        if (!dialogDict.ContainsKey(id)) { Debug.LogError($"{id} > 그런 Dialog ID 가 없습니다."); return null; }

        SetCurrentDialog(id);

        return dialogDict[id];
    }
    private void SetCurrentDialog(int id)
    {
        currentDialogId = id;
        currentIdx = 0;
    }
    /// <summary>
    /// 다음 대사 확인 함수
    /// </summary>
    /// <returns>False when current script is ended</returns>
    private bool TextLeft()
    {
        return dialogDict[currentDialogId].script.Count > currentIdx;
    }
}

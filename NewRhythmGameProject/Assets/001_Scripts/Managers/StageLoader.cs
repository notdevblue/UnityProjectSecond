using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// TODO : 스테이지 생성하면서 버튼을 List 에 넣음과 동시에 묶어 줘야 함
// TODO : etcBtnList 는 List 말고 하나하나 버튼으로 받는게 맞는 듯 하다.

public class StageLoader : MonoBehaviour
{
    public List<Button> btnList = new List<Button>(); // 스테이지 로드 위한 버튼
    // 나중에는 Add() 함수로 추가해야함
    public List<Button> etcBtnList = new List<Button>(); // 기타 로딩용 버튼

    private void Awake()
    {
        // LinkButton();
        btnList[0].onClick.AddListener(() => { // TODO : 디버그 용
            SceneManager.LoadScene("StageTestScene");
        });

        etcBtnList[0].onClick.AddListener(() => { // TODO : 함수로 빼야 함
            SceneManager.LoadScene("RecordScene");
        });
    }



    /// <summary>
    /// 스테이지 로드 기능을 버튼과 묶음
    /// </summary>
    private void LinkButton()
    {
        for (int i = 0; i < btnList.Count; ++i)
        {
            btnList[i].onClick.AddListener(() => {
                SceneManager.LoadScene($"Stage{i + 1}");
            });
        }
    }

    public void Add(Button btn)
    {
        btnList.Add(btn);
        LinkButton();
    }
}

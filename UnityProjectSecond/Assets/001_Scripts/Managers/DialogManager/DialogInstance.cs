using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogInstance : MonoSingleton<DialogInstance>
{
    // 본인 요소
    [SerializeField] private Text text;    
    [SerializeField] private Image icon;

    // 열리고 닫히는 위치
    [SerializeField] private Transform closedTrm = null;
    [SerializeField] private Transform openedTrm = null;
    [SerializeField] private float duration; // 열리고 닫히는 시간

    private bool isOpen = false;
    public bool IsOpen
    {
        get
        {
            return isOpen;
        }
        private set
        {
            isOpen = value;

            // 열고 닫는 함수 만들기 싫었스빈다.
            switch(value)
            {
                case true:
                    transform.DOMove(openedTrm.position, duration).SetEase(Ease.OutBack);
                    break;

                case false:
                    transform.DOMove(closedTrm.position, duration).SetEase(Ease.InBack);
                    break;
            }
        }
    }


    /// <summary>
    /// Dialog 를 엽니다.
    /// </summary>
    /// <param name="text">텍스트</param>
    /// <param name="icon">아이콘</param>
    public void Show(string text, Sprite icon)
    {
        if(!IsOpen) IsOpen = true; // 안 열려있으면 열어줌

        // 이미지와 텍스트 설정
        this.text.text   = text;
        this.icon.sprite = icon;
    }

    public void Close()
    {
        // 닫혀있는 상태에서 닫히는 버그를 방지
        if(IsOpen) IsOpen = false;
    }
}

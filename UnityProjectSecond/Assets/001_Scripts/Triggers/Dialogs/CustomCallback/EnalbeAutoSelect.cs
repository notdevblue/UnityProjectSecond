using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 커스텀 콜백 시스템
// 다이얼로그의 자식 오브젝트로 추가하면 종료 시 Callback() 을 호출합니다.

public class EnalbeAutoSelect : MonoBehaviour, IDialogCallback
{
    public void Callback()
    {
        PlayerStatus.Instance.autoHookAble = true;
    }
}

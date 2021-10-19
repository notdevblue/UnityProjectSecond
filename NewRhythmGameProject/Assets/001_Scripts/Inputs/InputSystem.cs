using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoSingleton<InputSystem>
{
    private List<KeyCode> firstLineInput  = new List<KeyCode>();
    private List<KeyCode> secondLineInput = new List<KeyCode>();
    private List<KeyCode> thirdLineInput  = new List<KeyCode>();

    private InputJson inputKeyCodes = new InputJson();

    public event Action OnKeyFirstline;
    public event Action OnKeySecondline;
    public event Action OnKeyThirdline;

    private void Start()
    {
        JsonFileOverrideManager.Instance.SetJsonData(inputKeyCodes);

        firstLineInput  = inputKeyCodes.firstLineInput;
        secondLineInput = inputKeyCodes.secondLineInput;
        thirdLineInput  = inputKeyCodes.thirdLineInput;
    }


    private void Update()
    {
        CheckInput(firstLineInput, OnKeyFirstline);
        CheckInput(secondLineInput, OnKeySecondline);
        CheckInput(thirdLineInput, OnKeyThirdline);
    }

    /// <summary>
    /// 키 입력 확인 함수
    /// </summary>
    /// <param name="keyData">확인할 Keycode 가 담긴 List</param>
    /// <param name="callback">입력 시 실행될 함수</param>
    private void CheckInput(List<KeyCode> keyData, Action callback)
    {
        for (int i = 0; i < keyData.Count; ++i)
        {
            if (Input.GetKeyDown(keyData[i]))
            {
                callback();
            }
        }
    }
}

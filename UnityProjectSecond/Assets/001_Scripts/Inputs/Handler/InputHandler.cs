using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputHandler : MonoSingleton<InputHandler>
{
    private CharactorInput input;

    /// <summary>
    /// 오른쪽 이동 키 눌렀을 때 계속 호출됨
    /// </summary>
    public event Action OnKeyRight;

    /// <summary>
    /// 왼쪽 이동 키 눌렀을 때 계속 호출됨
    /// </summary>
    public event Action OnKeyLeft;

    /// <summary>
    /// 점프 시 호출됨
    /// </summary>
    public event Action OnKeyJump;

    /// <summary>
    /// 공격 버튼을 눌렀을 시 호출됨
    /// </summary>
    public event Action OnKeyAttack;

    /// <summary>
    /// 시간 버튼을 눌렀을 시 호출됨
    /// </summary>
    public event Action OnKeyTime;

    /// <summary>
    /// 아무 입력이 없을 때 호출됨
    /// </summary>
    public event Action OnIdle;

    protected override void Awake()
    {
        base.Awake();

        OnKeyRight  += () => { };
        OnKeyLeft   += () => { };
        OnKeyJump   += () => { };
        OnKeyAttack += () => { };
        OnKeyTime   += () => { };
    }

    private void Start()
    {
        input = JsonFileOverrideManager.Instance.Input;
    }

    void Update()
    {
        // Movement
        if(Input.GetKey(input.right))
        {
            OnKeyRight();
        }
        if(Input.GetKey(input.left))
        {
            OnKeyLeft();
        }
        if(Input.GetKeyDown(input.jump))
        {
            OnKeyJump();
        }

        // Attack
        if(Input.GetKeyDown(input.atk))
        {
            OnKeyAttack();
        }
        if(Input.GetMouseButtonDown((int)input.atkMouse))
        {
            OnKeyAttack();
        }

        // Time
        if(Input.GetKeyDown(input.timeSwitch))
        {
            OnKeyTime();
        }

        // idle
        if(!Input.anyKey)
        {
            OnIdle();
        }
    }
}

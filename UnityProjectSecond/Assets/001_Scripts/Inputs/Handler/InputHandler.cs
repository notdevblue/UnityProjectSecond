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
    /// 위 이동 키 눌렀을 때 계속 호출됨
    /// </summary>
    public event Action OnKeyUp;

    /// <summary>
    /// 아레 이동 키 눌렀을 때 계속 호출됨
    /// </summary>
    public event Action OnKeyDown;

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

    /// <summary>
    /// 마우스 휠 y Delta 넘겨줌
    /// </summary>
    public event Action<float> OnMouseWheel;

    /// <summary>
    /// 자동 훅 연결 입력 시 호출됨
    /// </summary>
    public event Action OnAutoHook;

    private void Awake()
    {

        OnKeyRight   += ()  => { };
        OnKeyLeft    += ()  => { };
        OnKeyUp      += ()  => { };
        OnKeyDown    += ()  => { };
        OnKeyJump    += ()  => { };
        OnKeyAttack  += ()  => { };
        OnKeyTime    += ()  => { };
        OnMouseWheel += (y) => { };
        OnAutoHook   += ()  => { };
    }

    private void Start()
    {
        input = JsonFileOverrideManager.Instance.Input;
    }

    void Update()
    {
        if (PlayerStatus.Instance.moveable)
        {
            // Movement
            if (Input.GetKey(input.right))
            {
                OnKeyRight();
            }
            if (Input.GetKey(input.left))
            {
                OnKeyLeft();
            }
            if (Input.GetKeyDown(input.jump))
            {
                OnKeyJump();
            }

            // 지금은 Hook 상태일때의 이동밖에 없습니다.
            if (Input.GetKey(input.up))
            {
                OnKeyUp();
            }
            if(Input.GetKey(input.down))
            {
                OnKeyDown();
            }

        }
            // Attack
        if (PlayerStatus.Instance.attackable &&
           (Input.GetKeyDown(input.atk) || Input.GetMouseButtonDown((int)input.atkMouse)))
        {
            OnKeyAttack();
        }
        

        // Time
        if(Input.GetKeyDown(input.timeSwitch))
        {
            OnKeyTime();
        }

        // Mouse Wheel Input
        OnMouseWheel(Input.mouseScrollDelta.y);

        // Auto Hook
        if (PlayerStatus.Instance.autoHookAble &&
           (Input.GetKeyDown(input.autoHook) || Input.GetMouseButtonDown((int)input.autoHookMouse)))
        {
            OnAutoHook();
        }


        // idle
        if(!Input.anyKey)
        {
            OnIdle();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : AIBase
{
    /// <summary>
    /// 탈진 상태 시 호출됨
    /// </summary>
    public System.Action OnExhausted;
    /// <summary>
    /// 탈진 상태 종료 시 호출됨
    /// </summary>
    public System.Action OnExhaustedEnd;

    public bool Exhausted { get; private set; }

    public float[] exhaustedHpPercent = new float[0]; // 탈진 상태가 될 HP 비율

    [SerializeField] private float exhausedTime = 15.0f;

    private int curExhaustedIndex = 0;



    private void Start()
    {
        OnExhausted += () => {
            Invoke(nameof(UnsetExhausted), exhausedTime); // 탈진 상태 탈출
        };

        OnExhaustedEnd += () => { };
    }

    protected override bool CanDecide()
    {
        return base.CanDecide() && !Exhausted;
    }

    public override void OnDamage(int damage)
    {
        if(CheckExhausted()) SetExhausted();

        base.OnDamage(damage);
    }

    /// <summary>
    /// 탈진 상태가 되야 하는지 확인합니다.
    /// </summary>
    /// <returns>True when Exhaused</returns>
    private bool CheckExhausted()
    {
        if(exhaustedHpPercent.Length <= curExhaustedIndex) return false;

        return ((float)curHp / (float)maxHp) <= exhaustedHpPercent[curExhaustedIndex];
    }

    /// <summary>
    /// 탈진 상태로 변경합니다.
    /// </summary>
    protected void SetExhausted()
    {
        Exhausted = true;
        ++curExhaustedIndex;
        OnExhausted();
    }

    /// <summary>
    /// 탈진 상태에서 탈출합니다.
    /// </summary>
    protected void UnsetExhausted()
    {
        Exhausted = false;
        OnExhaustedEnd();
    }

}

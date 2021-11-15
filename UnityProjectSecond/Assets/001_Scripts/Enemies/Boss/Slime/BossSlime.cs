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

        GameManager.Instance.OnBossBattleEnter += () => { // 들어가자마자 바로 공격하는건 초큼...
            nextDecisionTime = Time.time;
        };
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

    protected override void Dead(bool DO_NOT_DISABLE = false) // Disable 이 아닌 Destroy 할 것
    {  
        base.Dead(true);
    }

    /// <summary>
    /// 탈진 상태가 되야 하는지 확인합니다.
    /// </summary>
    /// <returns>True when Exhaused</returns>
    private bool CheckExhausted()
    {
        if(exhaustedHpPercent.Length <= curExhaustedIndex) return false;

        return ((float)curHp / (float)maxHp) * 100.0f <= exhaustedHpPercent[curExhaustedIndex];
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

    protected new void Disable() // Dead 에니메이션 클립에서 실행됨
    {
        GameManager.Instance.OnBossBattle = false;
        Destroy(gameObject);
    }

}

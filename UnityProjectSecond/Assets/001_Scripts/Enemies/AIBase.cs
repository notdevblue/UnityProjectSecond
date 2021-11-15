using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 보스든 슬라임이든 모든 AI 가 상속받는 클래스<br/>~보스 슬라임이면 당연히 상속받아햐하는것인가?~
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
abstract public class AIBase : MonoBehaviour, IDamageable
{

    public event Action OnDamaged; // 데미지 받았을 시 호출
    public event Action OnDead; // 사망 시 호출

    [SerializeField] protected int maxHp = 20;
    [SerializeField] private float DEATH_ANIM_TIME = 0.5f; // 사망 에니메이션 끝난 후 Disable 위해
    [SerializeField] private float decisionDelayTime = 2.0f;
    [SerializeField] private float decisionDelayRandomTime = 0.5f;

    protected Rigidbody2D rigid;
    protected int curHp; // curHp = maxHp
    
    private List<AIVO> decisionList = new List<AIVO>(); // 선택 위함

    private bool decisionActFinished = true; // 선택한 행동이 끝났는지

    protected float nextDecisionTime = 0; // 다음 선택 시간 (보스 AI 때문에 protected)



    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        curHp = maxHp;

        OnDamaged += () => { };
        OnDead    += () => { };

        nextDecisionTime = Time.time;
    }

    protected virtual void Update()
    {
        // 다음 행동 선택
        if (CanDecide())
        {
            nextDecisionTime = Time.time + UnityEngine.Random.Range(decisionDelayTime - decisionDelayRandomTime, decisionDelayTime + decisionDelayRandomTime);

            for (int i = 0; i < decisionList.Count; ++i)
            {
                int decision = UnityEngine.Random.Range(0, decisionList.Count);

                decisionList[decision].what();
            }
        }
    }

    /// <summary>
    /// 선택을 정할 수 있는지 여부
    /// </summary>
    /// <returns>True when slime can decide</returns>
    protected virtual bool CanDecide()
    {
        return decisionActFinished && nextDecisionTime <= Time.time && GameManager.Instance.OnBossBattle;
    }

    public virtual void OnDamage(int damage) // 데미지 받았을 시 호출
    {
        curHp -= damage;
        OnDamaged();
        if(curHp <= 0)
            Dead();
    }

    protected virtual void Dead(bool DO_NOT_DISABLE = false) // 사망 시 호출
    {
        if(!DO_NOT_DISABLE)
            Invoke(nameof(Disable), DEATH_ANIM_TIME); // Dead 에니메이션 재생 시간
        OnDead();
    }

    protected virtual void Disable()
    {
        gameObject.SetActive(false); // pooling 용도 (아마도)
    }
    
    /// <summary>
    /// 선택을 추가합니다.
    /// </summary>
    public void AddDecision(AIVO decision)
    {
        if (decision == null) { Debug.LogError($"{gameObject.name}::AIBase > Decision cannot be null."); return; }

        decision.what += () => {
            decisionActFinished = false;
        };

        decisionList.Add(decision);
    }

    /// <summary>
    /// 행동 종료를 선언합니다.
    /// </summary>
    public void SetActFinished()
    {
        decisionActFinished = true;
    }
}

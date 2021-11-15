using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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

    private float nextDecisionTime = float.MinValue; // 다음 선택 시간



    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

        curHp = maxHp;

        OnDamaged += () => { };
        OnDead    += () => { };
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
        return decisionActFinished && nextDecisionTime <= Time.time;
    }

    public virtual void OnDamage(int damage) // 데미지 받았을 시 호출
    {
        curHp -= damage;
        OnDamaged();
        if(curHp <= 0)
            Dead();
    }

    protected virtual void Dead() // 사망 시 호출
    {
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AIBase : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHp = 20;

    [SerializeField] private float DEATH_ANIM_TIME = 0.5f;
    private int curHp;

    public event Action OnDamaged;
    public event Action OnDead;

    protected virtual void Awake()
    {
        curHp = maxHp;

        OnDamaged += () => { };
        OnDead    += () => { };
    }

    public virtual void OnDamage(int damage)
    {
        curHp -= damage;
        OnDamaged();
        if(curHp <= 0)
            Dead();
    }

    protected virtual void Dead()
    {
        Invoke(nameof(Disable), DEATH_ANIM_TIME); // Dead 에니메이션 재생 시간
        OnDead();
    }

    protected virtual void Disable()
    {
        gameObject.SetActive(false); // pooling 용도 (아마도)
    }

    
}

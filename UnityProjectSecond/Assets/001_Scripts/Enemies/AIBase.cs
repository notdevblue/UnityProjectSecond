using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AIBase : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHp = 20;
    private int curHp;

    protected virtual void Awake()
    {
        curHp = maxHp;
    }

    public virtual void OnDamage(int damage)
    {
        curHp -= damage;
        if(curHp <= 0)
            Dead();
    }

    abstract protected void Dead();
}

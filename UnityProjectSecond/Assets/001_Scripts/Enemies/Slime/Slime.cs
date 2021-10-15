using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Slime : AIBase
{
    public event Action OnDamaged;
    public event Action OnDead;

    protected override void Awake()
    {
        base.Awake();
        OnDamaged += () => { };
    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
        OnDamaged();
    }

    protected override void Dead()
    {
        OnDead();
        Invoke(nameof(Disable), 0.5f); // Dead 에니메이션 재생 시간
    }

    private void Disable()
    {
        gameObject.SetActive(false); // pooling 용도 (아마도)
    }

}

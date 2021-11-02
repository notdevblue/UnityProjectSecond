using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(CircleCollider2D))]
public class Slime : AIBase, IPushable
{
    const float DEATH_ANIM_TIME = 0.5f;

    private Rigidbody2D rigid;

    public event Action OnDamaged;
    public event Action OnDead;
    public event Action OnMove;
    public event Action OnIdle;



    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody2D>();
        
        OnDamaged += () => { };
        OnDead    += () => { };
        OnMove    += () => { };
        OnIdle    += () => { };
    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
        OnDamaged();
    }

    protected override void Dead()
    {
        OnDead();
        Invoke(nameof(Disable), DEATH_ANIM_TIME); // Dead 에니메이션 재생 시간
    }

    private void Disable()
    {
        gameObject.SetActive(false); // pooling 용도 (아마도)
    }

    public void Push(Vector2 normal, float amount = 1)
    {
        PhysicsManager.Instance.PushObj(rigid, normal.normalized, amount);
    }
}

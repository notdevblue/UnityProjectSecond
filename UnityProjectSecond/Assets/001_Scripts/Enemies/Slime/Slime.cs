using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(CircleCollider2D))]
public class Slime : AIBase, IPushable
{
    private Rigidbody2D rigid;

    protected override void Awake()
    {
        base.Awake();
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Push(Vector2 normal, float amount = 1)
    {
        PhysicsManager.Instance.PushObj(rigid, normal.normalized, amount);
    }
}

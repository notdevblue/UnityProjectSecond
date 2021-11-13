using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(CircleCollider2D))]
public class Slime : AIBase, IPushable
{
    public bool isAttackable = true;

    public void Push(Vector2 normal, float amount = 1)
    {
        PhysicsManager.Instance.PushObj(rigid, normal.normalized, amount);
    }
}

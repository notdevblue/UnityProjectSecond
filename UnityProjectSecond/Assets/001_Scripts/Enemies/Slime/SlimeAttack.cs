using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : AIAttack
{
    [SerializeField] private int   damage   = 1;
    [SerializeField] private float atkDelay = 1.0f;
    [SerializeField] private float upPushForce = 1.5f;

    private Slime slime;

    private void Start()
    {
        slime = GetComponent<Slime>();
    }

    float lastAttackTime = float.MinValue;

    protected override void Attack(Collision2D other)
    {
        if (slime.isAttackable && lastAttackTime + atkDelay < Time.time)
        {
            lastAttackTime = Time.time;

            Vector2 normal;
            normal.x = -other.GetContact(0).normal.x;
            normal.y = upPushForce;

            other.transform.GetComponent<IPushable>()?.Push(normal, damage);
            other.transform.GetComponent<IDamageable>()?.OnDamage(damage);
        }
    }
}

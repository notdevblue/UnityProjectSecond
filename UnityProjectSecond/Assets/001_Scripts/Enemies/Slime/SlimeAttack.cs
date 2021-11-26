using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : AIAttack
{

    private Slime slime;

    private void Start()
    {
        slime = GetComponent<Slime>();
    }

    protected override void Attack(Collision2D other)
    {
        if (slime.isAttackable && lastAttackTime + atkDelay < Time.time)
        {
            lastAttackTime = Time.time;

            Vector2 normal;
            normal.x = -other.GetContact(0).normal.x;
            normal.y = upPushForce;

            other.transform.GetComponent<IPushable>()?.Push(normal, damage); // other 를 튕겨냄
            other.transform.GetComponent<IDamageable>()?.OnDamage(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AIAttack : MonoBehaviour
{
    const string PLAYER = "PLAYER";

    [SerializeField] protected int damage = 1;
    [SerializeField] protected float atkDelay = 1.0f;

    [SerializeField] protected float upPushForce = 1.5f; // 데미지 준 물체 y 미는 힘

    protected float lastAttackTime = float.MinValue;

    abstract protected void Attack(Collision2D other);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.CompareTag(PLAYER))
        {
            Attack(other);
        }
    }
}

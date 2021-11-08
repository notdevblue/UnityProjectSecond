using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public event Action onDamage;
    public event Action onDeath;

    [SerializeField] private float damageDelay = 1.0f;

    private float lastattackedTime = float.MinValue;



    private void Awake()
    {
        PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;

        onDamage += () => { };
        onDeath  += () => { };
    }


    public void OnDamage(int damage)
    {
        if(lastattackedTime + damageDelay > Time.time) return;

        lastattackedTime               = Time.time;
        PlayerStatus.Instance.attacked = true;
        PlayerStatus.Instance.hp      -= damage;

        onDamage();

        if(PlayerStatus.Instance.hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        onDeath();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float lastAtkTime = float.MinValue;
    private bool canAttack = false;

    private void Start()
    {
        InputHandler.Instance.OnKeyAttack += () => {
            if(Time.time < lastAtkTime + PlayerStats.Instance.atkDelay) return; // 공격 딜레이
            lastAtkTime = Time.time;

            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right * this.transform.localScale.x, PlayerStats.Instance.atkDistance);

            if(hit.collider != null)
            {
                hit.transform.GetComponent<IDamageable>()?.OnDamage(PlayerStats.Instance.atkDamage);
            }
        };
    }
}

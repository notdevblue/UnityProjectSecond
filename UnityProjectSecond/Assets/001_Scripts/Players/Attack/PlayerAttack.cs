using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float lastAtkTime = float.MinValue;
    private bool canAttack = false;

    private int ignoreLayer;
    private float pushForce;

    private void Start()
    {
        ignoreLayer = ~(1 << gameObject.layer); // 플레이어 레이어 무시
        pushForce = PlayerStats.Instance.atkDamage / 1.25f;

        InputHandler.Instance.OnKeyAttack += () => {
            if(Time.time < lastAtkTime + PlayerStats.Instance.atkDelay) return; // 공격 딜레이
            lastAtkTime = Time.time;

            // 공격 ray
            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right * this.transform.localScale.x, PlayerStats.Instance.atkDistance, ignoreLayer);
            if(hit.collider != null)
            {
                hit.transform.GetComponent<IDamageable>()?.OnDamage(PlayerStats.Instance.atkDamage);
                hit.transform.GetComponent<IPushable>()?.Push(-hit.normal + Vector2.up, pushForce); // TODO : 미리 계산 해 두고 저장
            }

        };
    }
}

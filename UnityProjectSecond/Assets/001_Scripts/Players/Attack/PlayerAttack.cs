using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float lastAtkTime = float.MinValue;
    private bool canAttack = false;

    private int ignoreLayer;

    private void Start()
    {
        ignoreLayer = ~(1 << gameObject.layer); // 플레이어 레이어 무시

        InputHandler.Instance.OnKeyAttack += () => {
            if(Time.time < lastAtkTime + PlayerStats.Instance.atkDelay) return; // 공격 딜레이
            lastAtkTime = Time.time;

            RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.right * this.transform.localScale.x, PlayerStats.Instance.atkDistance, ignoreLayer);

            if(hit.collider != null)
            {
                hit.transform.GetComponent<IDamageable>()?.OnDamage(PlayerStats.Instance.atkDamage);
            }
        };
    }
}

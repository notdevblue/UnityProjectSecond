using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFov : MonoBehaviour
{
    const string PLAYER_LAYER = "PLAYER";

    [Range(0.0f, 360.0f)]
    public float viewAngle = 40.0f;

    public float ViewRange { get; set; } // 아이템 등의 이유로 줄어들 수 있을수도
    public float AttackRange { get; set; }

    [SerializeField] private LayerMask whatIsObstacle;

    private int playerLayer; // 플레이어의 LayerMask 값
    private AIMove aiMove;

    private void Awake()
    {
        aiMove = GetComponent<AIMove>();
        playerLayer = LayerMask.NameToLayer(PLAYER_LAYER);
    }

    public Vector2 CirclePoint(float angle)
    {
        angle += aiMove.GetFront().x < 0 ? -90.0f : 90.0f;

        return new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad),
                           Mathf.Cos(((byte)angle) * Mathf.Deg2Rad));
        
    }

    public bool IsTracePlayer()
    {
        bool isTrace = false;
        Collider2D col = Physics2D.OverlapCircle(transform.position, viewAngle, 1 << playerLayer);

        if (col != null)
        {
            // z축 필요없으니 벡터 2로 변환시킴
            Vector2 dir = GameManager.Instance.player.transform.position - transform.position;

            if (Vector2.Angle(aiMove.GetFront(), dir) < viewAngle * 0.5f)
            {
                isTrace = true;
            }

        }

        return isTrace;
    }

    public bool IsViewPlayer()
    {
        bool isView = false;
        Vector2 dir = GameManager.Instance.player.transform.position - transform.position;
        RaycastHit2D hit2D = Physics2D.Raycast
            (transform.position, dir.normalized, ViewRange, whatIsObstacle);

        if (hit2D.collider != null)
        {
            isView = (hit2D.collider.gameObject.CompareTag(PLAYER_LAYER));
        }

        return isView;
    }

    public bool IsAttackPossible()
    {
        return (GameManager.Instance.player.transform.position - transform.position).sqrMagnitude
            <= Mathf.Pow(AttackRange, 2);
    }



}

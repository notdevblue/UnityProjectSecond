using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AIMove : MonoBehaviour
{
    const float FULL   = 1.0f;
    const float WEIGHT = 0.6f;
    const float HALF   = 0.5f;
    const float LESS   = FULL - WEIGHT;
    const float ZERO   = 0.0f;


    // 순찰 위치
    [SerializeField] private Transform partolPosBegin;
    [SerializeField] private Transform patrolPosEdgeBegin;

    [SerializeField] private Transform patrolPosEnd;
    [SerializeField] private Transform patrolPosEdgeEnd;

    protected Rigidbody2D rigid;

    protected float moveDelay;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public Vector2 GetFront()
    {
        return transform.localScale.x > 0.0f ? transform.right : -transform.right;
        // 스프라이트가 오른쪽을 보고 있는지 꼭 확인을
    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, 1.0f, 1.0f);
    }

    private void SetRight()
    {
        transform.localScale = Vector3.one;
    }

    private void SetLeft()
    {
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    }

    protected void Move()
    {
        float decideRightWeight;

        if (partolPosBegin.position.x > transform.position.x)
        {
            // force right;
            decideRightWeight = FULL;
        }
        else if (patrolPosEdgeBegin.position.x > transform.position.x)
        {
            // weight right;
            decideRightWeight = WEIGHT;
        }
        else if (patrolPosEnd.position.x < transform.position.x)
        {
            // force left;
            decideRightWeight = ZERO;
        }
        else if (patrolPosEdgeEnd.position.x < transform.position.x)
        {
            // weight left;
            decideRightWeight = LESS;
        }
        else
        {
            // equal;
            decideRightWeight = HALF;
        }

        float x = Random.Range(0.0f, 1.0f);

        if (decideRightWeight > x)
        {
            SetRight();
        }
        else
        {
            SetLeft();
        }
    }
}

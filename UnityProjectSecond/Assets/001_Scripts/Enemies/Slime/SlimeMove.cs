using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Slime))]
public class SlimeMove : AIMove
{
    [SerializeField] private float moveForce = 1.0f;

    private Slime slime = null;
    private Animator animator = null;

    private bool isMoving = false;
    private int moveHash = Animator.StringToHash("Move");



    protected override void Start()
    {
        base.Start();
        slime = GetComponent<Slime>();
        animator = GetComponent<Animator>();

        slime.OnDead += () => {
            isMoving = false;
            slime.isAttackable = false;
        };

        slime.OnDamaged += () => {
            isMoving = false;
        };
    }

    private void Update()
    {
        if (isMoving)
        {
            rigid.velocity = new Vector2(GetFront().x * moveForce, rigid.velocity.y);
        }
    }

    protected override void SetMove()
    {
        animator.SetTrigger(moveHash);
    }

    public void JumpStart() // 에니메이션에서 호출
    {
        isMoving = true;
    }

    public void JumpEnd() // 에니메이션에서 호출
    {
        isMoving = false;
    }

}

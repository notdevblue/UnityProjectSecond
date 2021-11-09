using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMove : AIMove
{
    [SerializeField] private float moveForce = 1.0f;

    private bool isMoving = false;

    private Slime slime = null;

    private void Start()
    {
        slime = GetComponent<Slime>();

        slime.OnDead += () => {
            isMoving = false;
            slime.isAttackable = false;
        };

        slime.OnDamaged += () => {
            isMoving = false;
        };
    }


    public void JumpStart()
    {
        isMoving = true;
    }

    public void JumpEnd()
    {
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            rigid.velocity = new Vector2(GetFront().x * moveForce, rigid.velocity.y);
        }
    }
}

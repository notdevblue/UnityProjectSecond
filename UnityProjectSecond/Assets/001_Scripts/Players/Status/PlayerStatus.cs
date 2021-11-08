using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoSingleton<PlayerStatus>
{
    public bool isMoving        = false;
    public bool isJumping       = false;
    public bool isDoubleJumping = false;
    public bool isAttacking     = false;
    public bool isDashing       = false;

    public bool onGround = true;
    public bool onHook   = false;
    public bool attacked = false;

    public bool moveable   = true;
    public bool jumpable   = true;
    public bool attackable = true;
    public bool dashable   = true;

    public int maxHp = 20;
    public int hp    = 20;

    private void Start()
    {
        GetComponent<PlayerHealth>().onDamage += () => {
            moveable = false;
            attackable = false;
            Invoke(nameof(AbleInput), PlayerStats.Instance.damageFreezeTime);
        };

        GetComponent<PlayerHealth>().onDeath += () => {
            CancelInvoke();
            moveable = false;
            attackable = false;
        };
    }

    private void AbleInput()
    {
        moveable = true;
        attackable = true;
    }

    public void ResetJumpStatus()
    {
        onGround = true;
        jumpable = true;
        isJumping = false;
        isDoubleJumping = false;
    }

}

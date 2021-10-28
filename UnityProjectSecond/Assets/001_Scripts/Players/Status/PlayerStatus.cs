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


    public void ResetJumpStatus()
    {
        onGround = true;
        jumpable = true;
        isJumping = false;
        isDoubleJumping = false;
    }
}

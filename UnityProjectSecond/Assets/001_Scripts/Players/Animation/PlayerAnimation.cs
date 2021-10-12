using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator       animator       = null;
    private SpriteRenderer spriteRenderer = null;

    private int jumpHash       = Animator.StringToHash("Jump");
    private int runHash        = Animator.StringToHash("Run");
    private int attackHash     = Animator.StringToHash("Attack");
    private int doubleJumpHasn = Animator.StringToHash("DoubleJump");

    private void Awake()
    {
        animator       = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Movement
        InputHandler.Instance.OnKeyRight += () => {
            animator.SetBool(runHash, true);
            spriteRenderer.flipX = false;
        };

        InputHandler.Instance.OnKeyLeft += () => {
            animator.SetBool(runHash, true);
            spriteRenderer.flipX = true;
        };


        // Attack
        InputHandler.Instance.OnKeyAttack += () => {
            animator.SetTrigger(attackHash);
        };


        // Jump
        InputHandler.Instance.OnKeyJump += () => {
            animator.SetTrigger(jumpHash);
        };


        // Idle
        InputHandler.Instance.OnIdle += () => {
            animator.SetBool(runHash, false);
        };
    }
}

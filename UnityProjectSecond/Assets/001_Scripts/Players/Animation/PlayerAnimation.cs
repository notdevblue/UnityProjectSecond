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

    private float lastAtktime = float.MinValue;

    private Vector3 flip = new Vector3(-1.0f, 1.0f, 1.0f);

    private void Awake()
    {
        animator       = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // Movement
        InputHandler.Instance.OnKeyRight += () =>
        {
            animator.SetBool(runHash, true);
            transform.localScale = Vector3.one; // Attack 의 ray 때문에 sprite.flip 안 씀
        };

        InputHandler.Instance.OnKeyLeft += () =>
        {
            animator.SetBool(runHash, true);
            transform.localScale = flip; // Attack 의 ray 때문에 sprite.flip 안 씀
        };


        // Attack
        InputHandler.Instance.OnKeyAttack += () =>
        {
            if (Time.time < lastAtktime + PlayerStats.Instance.atkDelay) return; // 공격 딜레이
            lastAtktime = Time.time;
            animator.SetTrigger(attackHash);
        };


        // Jump
        InputHandler.Instance.OnKeyJump += () =>
        {
            animator.SetTrigger(jumpHash);
        };


        // Idle
        InputHandler.Instance.OnIdle += () =>
        {
            animator.SetBool(runHash, false);
        };
    } // start(); end
}

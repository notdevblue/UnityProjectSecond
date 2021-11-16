using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator       animator       = null;
    private PlayerHealth   health         = null; // 데미지와 사망 이벤트

    private int jumpHash       = Animator.StringToHash("Jump");
    private int runHash        = Animator.StringToHash("Run");
    private int attackHash     = Animator.StringToHash("Attack");
    private int doubleJumpHasn = Animator.StringToHash("DoubleJump");
    private int attackedHash   = Animator.StringToHash("Attacked");
    private int deadHash       = Animator.StringToHash("Dead");

    private float lastAtktime = float.MinValue;

    private Vector3 flip = new Vector3(-1.0f, 1.0f, 1.0f);

    private void Awake()
    {
        animator = GetComponent<Animator>();
        health   = GetComponent<PlayerHealth>();
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

        health.onDamage += () => {
            animator.SetTrigger(attackedHash);
        };

        health.onDeath += () => {
            animator.SetTrigger(deadHash);
            Invoke(nameof(LoadScene), 1.0f);
        };

        // Idle
        InputHandler.Instance.OnIdle += () =>
        {
            animator.SetBool(runHash, false);
        };
    } // start(); end

    private void LoadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

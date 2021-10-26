using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim;

    // readonly int attackHash = Animator.StringToHash("Attack");
    readonly int attackHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        InputSystem.Instance.OnKeyFirstline += () => {
            Attack();
        };

        InputSystem.Instance.OnKeySecondline += () => {
            Attack();
        };

        InputSystem.Instance.OnKeyThirdline += () => {
            Attack();
        };

    }


    private void Attack()
    {
        anim.Play(attackHash, -1, 0);
    }

}

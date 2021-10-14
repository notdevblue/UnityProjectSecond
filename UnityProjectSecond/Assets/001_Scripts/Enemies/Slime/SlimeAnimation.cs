using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAnimation : MonoBehaviour
{
    private Animator animator = null;
    private Slime slime = null;

    private int attackedHash = Animator.StringToHash("Attacked");
    private int deadHash = Animator.StringToHash("Dead");

    private void Awake()
    {
        slime = GetComponent<Slime>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        slime.OnDamaged += () => {
            animator.SetTrigger(attackedHash);
        };

        slime.OnDead += () => {
            animator.SetTrigger(deadHash);
        };
    }

}

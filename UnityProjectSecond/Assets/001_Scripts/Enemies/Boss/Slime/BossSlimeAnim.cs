using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Animator), typeof(BossSlime))]
public class BossSlimeAnim : MonoBehaviour
{
    // [SerializeField] private float idleTime       = 0.5f;
    // [SerializeField] private float idleTimeRandom = 0.2f;

    [SerializeField] private float pushBackAmount = 0.2f;
    [SerializeField] private float pushBackDuration = 0.1f;

    private BossSlime bossSlime = null;
    private Animator animator   = null;

    private bool isDamagedAnimPlaying = false;
    private bool isExhausted = false;

    private Vector2 originPos;

    private int attack1Hash   = Animator.StringToHash("Attack1");
    private int attack2Hash   = Animator.StringToHash("Attack2");
    private int damagedHash   = Animator.StringToHash("Damaged");
    private int deadHash      = Animator.StringToHash("Dead");
    private int exhaustedHash = Animator.StringToHash("Exhausted");



    private void Start()
    {
        bossSlime = GetComponent<BossSlime>();
        animator = GetComponent<Animator>();

        originPos = transform.position;

        // bossSlime.AddDecision(new AIVO(() => { // idle, Weight 구현 후 추가할 것
        //     Invoke(nameof(bossSlime.SetActFinished), Random.Range(idleTime - idleTimeRandom, idleTime + idleTimeRandom));
        // }, -0.5f));

        bossSlime.AddDecision(new AIVO(() => { // Attack1
            animator.SetTrigger(attack1Hash);
        }));

        bossSlime.AddDecision(new AIVO(() => { // Attack2
            animator.SetTrigger(attack2Hash);
        }));

        bossSlime.OnDamaged += () => { // Damaged
            if(bossSlime.IsActFinished() && !isExhausted)
                animator.SetTrigger(damagedHash);
            PushBack();
        };

        bossSlime.OnDead += () => { // Dead
            animator.SetTrigger(deadHash);
        };

        bossSlime.OnExhausted += () => { // Exhausted enter, Called once
            isExhausted = true;
            animator.SetBool(exhaustedHash, true);
        };

        bossSlime.OnExhaustedEnd += () => { // Exhausted exit, Called once
            isExhausted = false;
            animator.SetBool(exhaustedHash, false);
        };
    }


    private void PushBack() // 데미지 에니메이션
    {
        transform.position = originPos;

        transform.DOMoveX(originPos.x + pushBackAmount, pushBackDuration).SetEase(Ease.Linear).OnComplete(() => {
            transform.DOMoveX(originPos.x, pushBackDuration).SetEase(Ease.Linear);
        });
    }
}

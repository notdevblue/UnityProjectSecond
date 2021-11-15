using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlimeAttack : AIAttack
{
    #region Attack1
    
    [Header("Spawn stats")]
    [SerializeField] private float fallObjSpawnDelay = 0.2f;
    [SerializeField] private int fallObjectMinCount = 2;
    [SerializeField] private int fallObjectMaxCount = 5;

    #endregion // Attack1

    [Header("(Only x coord. Y is spawnBeginTrm.position.y)")]
    [Header("Spawn location")]
    [SerializeField] private Transform spawnBeginTrm = null;
    [SerializeField] private Transform spawnEndTrm   = null;
    [SerializeField] private float slimeSpawnDistance = 0.5f; // 플레이어와 슬라임의 스폰 거리

    private Transform playerTrm; // 플레이어 포지션
    private WaitForSeconds wait;

    private void Start()
    {
        playerTrm = GameManager.Instance.player.transform;
        wait = new WaitForSeconds(fallObjSpawnDelay);
    }

    // 에니메이션 클립에서 실행시킴
    protected void GroundPound() // 함수 이름이 좀 그렇긴 하지만
    {
        // 낙하 오브젝트 스폰
        StartCoroutine(SpawnFallObjects(Random.Range(fallObjectMinCount, fallObjectMaxCount)));
    }

    // 에니메이션 클립에서 실행시킴
    protected void SummonSlime()
    {
        // 슬라임 생성
        if(spawnBeginTrm.position.x < playerTrm.position.x - slimeSpawnDistance) // 공간 확인
        {
            Random.Range(spawnBeginTrm.position.x, playerTrm.position.x - slimeSpawnDistance);
        }
        if(spawnEndTrm.position.x > playerTrm.position.x + slimeSpawnDistance) // 공간 확인
        {
            Random.Range(playerTrm.position.x + slimeSpawnDistance, spawnEndTrm.position.x);
        }

        Vector2 targetPos = new Vector2(Random.Range(spawnBeginTrm.position.x, spawnEndTrm.position.x), spawnBeginTrm.position.y);

        SlimePoolManager.Instance.Get();
    }

    // 낙하물 생성함
    private IEnumerator SpawnFallObjects(int count)
    {
        for (int i = 0; i < count; ++i)
        {
            FallingPoolManager.Instance.Get(new Vector2(Random.Range(spawnBeginTrm.position.x, spawnEndTrm.position.x), spawnBeginTrm.position.y));
            yield return wait;
        }
    }



    protected override void Attack(Collision2D other) // 몸빵
    {
        if (lastAttackTime + atkDelay < Time.time)
        {
            lastAttackTime = Time.time;

            Vector2 normal;
            normal.x = -other.GetContact(0).normal.x;
            normal.y = upPushForce;

            other.transform.GetComponent<IPushable>()?.Push(normal, damage);
            other.transform.GetComponent<IDamageable>()?.OnDamage(damage);
        }
    }
}

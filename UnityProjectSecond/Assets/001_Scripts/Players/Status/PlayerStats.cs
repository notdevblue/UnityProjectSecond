using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 플레이어 스텟
public class PlayerStats : MonoSingleton<PlayerStats>
{
    // 공격
    public float atkDelay = 0.8f; // 공격 딜레이
    public float atkDistance = 1.0f; // 공격 거리
    public int atkDamage = 5; // 공격 데미지

    // 이동
    public float speed = 10.0f; // 이동 속도
    public float vSpeed = 5.0f; // 수직 이동 속도
    public float jumpForce = 10.0f; // 점프 힘
    public float swingForce = 5.0f; // 훅 스윙 힘

    public float damageFreezeTime = 0.3f; // 피격 시 입력 무시 길이

}

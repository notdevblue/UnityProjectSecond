using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject player;

    const string PLAYER = "PLAYER";

    // 추후 HookManager?
    public float distanceWithHook = 2.0f; // 훅과 플레이어의 거리
    public Rigidbody2D curHookedRigid = null; // 지금 건 훅의 Rigid


}

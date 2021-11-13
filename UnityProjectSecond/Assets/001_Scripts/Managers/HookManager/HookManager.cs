using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookManager : MonoSingleton<HookManager>
{
    const string PLAYER = "PLAYER";

    public float minDistWithHook = 0.1f;
    public float maxDistWithHook = 3.0f;

    public HingeJoint2D CurHookedHinge
    {
        get
        {
            return curhookedhinge;
        }
        set
        {
            switch(value == null) // 만약 무언가에 연결했다면 선을 활성화시킴
            {
                case true:
                    hookLine.SetActive(false);
                    break;

                case false:
                    hookLine.SetActive(true);
                    break;
            }

            curhookedhinge = value;
        }
    } // 지금 건 훅의 Rigid

    public HingeJoint2D PlayerHinge { get; private set; }
    public Rigidbody2D PlayerHingeRigid { get; private set; }

    [SerializeField] private GameObject hookLine = null; // 훅 선
    
    private HingeJoint2D curhookedhinge = null;

    private GameObject player = null;



    private void Start()
    {
        player = GameManager.Instance.player;

        hookLine.SetActive(false);

        PlayerHinge = player.GetComponentInChildren<HingeJoint2D>();
        PlayerHingeRigid = PlayerHinge.GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// 훅 포인트와 연결을 종료합니다.
    /// </summary>
    public void ResetConnectedHinge()
    {
        if (CurHookedHinge != null)
        {
            player.transform.SetParent(null);
            CurHookedHinge.connectedBody = null;
            CurHookedHinge = null;
        }
    }

    public bool CanHook(Vector2 pos)
    {
        return Vector2.Distance(player.transform.position, pos) <= maxDistWithHook;
    }

    private void Update()
    {
        if(hookLine.activeSelf)
        {
            // 플레이어 기준으로 작성한 코드.
            hookLine.transform.position    = player.transform.position + (CurHookedHinge.transform.position - player.transform.position) / 2.0f;
            hookLine.transform.localScale  = new Vector2(0.1f, Vector2.Distance(CurHookedHinge.transform.position, player.transform.position));
            hookLine.transform.eulerAngles = new Vector3(0.0f, 0.0f, Mathf.Atan2(player.transform.position.y - CurHookedHinge.transform.position.y,
                                                                                 player.transform.position.x - CurHookedHinge.transform.position.x) * Mathf.Rad2Deg + 90.0f); // wa! Atan2! 오늘배운거 바로써먹기!
        }
    }
}

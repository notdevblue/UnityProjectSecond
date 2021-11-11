using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : Selectable
{

#region const strings
    private const string PLAYER = "PLAYER";
#endregion

    private int layer; // 무시할 레이어 들
    private Transform playerTrm = null; // 플레이어 Transform

    private HingeJoint2D hookPositionHinge; // 훅 거는 위치의 HingeJoint2D

    private void Start()
    {
        playerTrm         = GameManager.Instance.player.transform;
        hookPositionHinge = GetComponentInChildren<HingeJoint2D>();
        layer             = LayerMask.GetMask("PLAYER");
        layer            += LayerMask.GetMask("GROUND");
    }

    public override void DeFocus()
    {
        
    }

    public override void Focus()
    {

    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    // public override void Selected()
    // {
    //     // 사이에 가리는 것이 없는지 확인
    //     RaycastHit2D ray = Physics2D.Raycast(transform.position, playerTrm.position - transform.position, 10.0f, layer);

    //     if(ray.collider != null)
    //     {
    //         if(ray.collider.CompareTag(PLAYER))
    //         {
    //             // 위치로 이동
    //             Vector3 targetPos   = transform.position;
    //                     targetPos.z = playerTrm.position.z; // z 값 고정
    //             playerTrm.position  = targetPos;

    //             // 위치에 고정
    //             PhysicsManager.Instance.SetGravity(playerRigid, 0.0f);
    //             PhysicsManager.Instance.SetVelocity(playerRigid, Vector2.zero);
                
    //             // 상태 저장
    //             PlayerStatus.Instance.onHook = true;

    //             //점프 상태 초기회
    //             PlayerStatus.Instance.ResetJumpStatus();
    //         }
    //     }
    // }

    public override void Selected()
    {
        // 사이에 가리는 것이 없는지 확인
        RaycastHit2D ray = Physics2D.Raycast(transform.position, playerTrm.position - transform.position, 10.0f, layer);

        if(ray.collider != null)
        {
            if(ray.collider.CompareTag(PLAYER) && GameManager.Instance.CanHook(transform.position))
            {
                if(GameManager.Instance.curHookedHinge != null)
                {
                    // 연결 해제 후 연결
                    GameManager.Instance.ResetConnectedHinge();

                }

                // 연결
                playerTrm.SetParent(this.transform); // y 움직임 때문에
                hookPositionHinge.connectedBody = GameManager.Instance.PlayerHingeRigid;

                // 상태 저장
                PlayerStatus.Instance.onHook = true;
                GameManager.Instance.curHookedHinge = hookPositionHinge;

                //점프 상태 초기회
                PlayerStatus.Instance.ResetJumpStatus();
            }
        }
    }
}

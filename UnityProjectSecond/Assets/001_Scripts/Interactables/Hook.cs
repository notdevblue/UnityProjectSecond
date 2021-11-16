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

        HookManager.Instance.AddToAutoHookAvalibleList(this); // 자동 훅 가능 리스트에 추가
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

    public override void Selected()
    {
        if(!CanConnect()) return; // TODO : 야매. 나중에 더 좋은 방법으로 고쳐야 함

        if(HookManager.Instance.CurHookedHinge != null)
        {
            // 연결 해제 후 연결
            HookManager.Instance.ResetConnectedHinge();
        }

        // 연결
        playerTrm.SetParent(this.transform); // y 움직임 때문에
        hookPositionHinge.connectedBody = HookManager.Instance.PlayerHingeRigid;

        // 상태 저장
        PlayerStatus.Instance.onHook = true;
        HookManager.Instance.CurHookedHinge = hookPositionHinge;

        //점프 상태 초기회
        PlayerStatus.Instance.ResetJumpStatus();
    }

    public bool CanConnect()
    {
        // 사이에 가리는 것이 없는지 확인
        RaycastHit2D ray = Physics2D.Raycast(transform.position, playerTrm.position - transform.position, 10.0f, layer);

        return ray.collider != null && ray.collider.CompareTag(PLAYER) && HookManager.Instance.CanHook(transform.position);
    }
}

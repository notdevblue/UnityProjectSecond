using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#warning 이름이 잘못됨
public class Hook : MonoBehaviour, ISelectable
{
    private int ignoreLayer;
    private const string PLAYER = "PLAYER";
    private Transform playerTrm = null;
    private Rigidbody2D playerRigid = null;

    private void Start()
    {
        playerTrm = GameManager.Instance.player.transform;
        playerRigid = GameManager.Instance.player.GetComponent<Rigidbody2D>();
        ignoreLayer = ~(1 << gameObject.layer);
    }

    public void DeFocus()
    {

    }

    public void Focus()
    {

    }

    public void Selected()
    {
        // 사이에 가리는 것이 없는지 확인
        RaycastHit2D ray = Physics2D.Raycast(transform.position, playerTrm.position - transform.position, 10.0f, ignoreLayer);

        if(ray.collider != null)
        {
            if(ray.collider.CompareTag(PLAYER))
            {   
                // 위치로 이동
                playerTrm.position = transform.position;

                // 위치에 고정
                PhysicsManager.Instance.SetGravity(playerRigid, 0.0f);
                PhysicsManager.Instance.SetVelocity(playerRigid, Vector2.zero);
                
                // 상태 저장
                PlayerStatus.Instance.onHook = true;
            }
        }
    }



}
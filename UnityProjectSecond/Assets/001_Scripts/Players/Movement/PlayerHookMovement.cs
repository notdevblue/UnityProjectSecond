// using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookMovement : MonoBehaviour
{
    private Rigidbody2D rigid = null;
    private HingeJoint2D hinge = null;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        hinge = GetComponentInChildren<HingeJoint2D>();
    }


    private void Start()
    {

        InputHandler.Instance.OnKeyLeft += () => {
            if (PlayerStatus.Instance.moveable && PlayerStatus.Instance.onHook)
            {
                rigid.AddForce(Vector2.left * PlayerStats.Instance.swingForce * Time.deltaTime, ForceMode2D.Impulse);
                PlayerStatus.Instance.isMoving = true;
            }
        };

        InputHandler.Instance.OnKeyRight += () => {
            if (PlayerStatus.Instance.moveable && PlayerStatus.Instance.onHook)
            {
                rigid.AddForce(Vector2.right * PlayerStats.Instance.swingForce * Time.deltaTime, ForceMode2D.Impulse);
                PlayerStatus.Instance.isMoving = true;
            }
        };

        InputHandler.Instance.OnKeyJump += () => {
            HookManager.Instance.ResetConnectedHinge();
        };

        InputHandler.Instance.OnKeyUp += () => {
            if(PlayerStatus.Instance.onHook)
            {
                float yLength = HookManager.Instance.CurHookedHinge.transform.position.y - transform.position.y;

                if(HookManager.Instance.minDistWithHook < yLength)
                {
                    transform.position += transform.up * PlayerStats.Instance.vSpeed * Time.deltaTime;
                }

            }
        };

        InputHandler.Instance.OnKeyDown += () => {
            if (PlayerStatus.Instance.onHook)
            {
                float yLength = HookManager.Instance.CurHookedHinge.transform.position.y - transform.position.y;

                if (HookManager.Instance.maxDistWithHook > yLength)
                {
                    transform.position -= transform.up * PlayerStats.Instance.vSpeed * Time.deltaTime;
                }
            }
        };


    } // start() end

}

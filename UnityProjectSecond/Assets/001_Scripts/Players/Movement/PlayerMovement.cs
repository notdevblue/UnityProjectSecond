using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPushable
{
    private Rigidbody2D rigid = null;

    [SerializeField] LayerMask whatIsGround; // 바닥 체크 용도


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {

        // Movement
        InputHandler.Instance.OnKeyLeft += () =>
        {
            if (PlayerStatus.Instance.moveable)
            {
                switch(PlayerStatus.Instance.onHook)
                {
                    case true:
                        GameManager.Instance.curHookedRigid.AddTorque(-PlayerStats.Instance.swingForce * Time.deltaTime, ForceMode2D.Impulse);
                        break;

                    case false:
                        transform.position += Vector3.left * PlayerStats.Instance.speed * Time.deltaTime;
                        break;
                }
                PlayerStatus.Instance.isMoving = true;
            }
        };

        InputHandler.Instance.OnKeyRight += () =>
        {

            if (PlayerStatus.Instance.moveable)
            {
                switch (PlayerStatus.Instance.onHook)
                {
                    case true:
                        GameManager.Instance.curHookedRigid.AddTorque(PlayerStats.Instance.swingForce * Time.deltaTime, ForceMode2D.Impulse);
                        break;

                    case false:
                        transform.position += Vector3.right * PlayerStats.Instance.speed * Time.deltaTime;
                        break;
                }
                PlayerStatus.Instance.isMoving = true;
            }
        };

        // Jump
        InputHandler.Instance.OnKeyJump += () =>
        {
            if(PlayerStatus.Instance.onHook)
            {
                ResetPhysics();
                PlayerStatus.Instance.onHook = false;
                transform.SetParent(null);
                GameManager.Instance.curHookedRigid = null;
            }

            if (PlayerStatus.Instance.jumpable)
            {
                switch(!PlayerStatus.Instance.isJumping && PlayerStatus.Instance.onGround)
                {
                    case true: // 일반 점프
                        PlayerStatus.Instance.isJumping = true;
                        PlayerStatus.Instance.onGround = false;
                        break;

                    case false: // 더블 점프
                        PlayerStatus.Instance.isDoubleJumping = true;
                        PlayerStatus.Instance.jumpable = false;

                        if (!PlayerStatus.Instance.onHook)
                        {
                            rigid.velocity = new Vector2(rigid.velocity.x, 0.0f);
                        }
                        break;
                }

                rigid.AddForce(Vector2.up * PlayerStats.Instance.jumpForce, ForceMode2D.Impulse);
            }
        };

        InputHandler.Instance.OnIdle += () =>
        {
            PlayerStatus.Instance.isMoving = false;
        };
    } // start() end

    private void Update()
    {
        #region 바닥 채크
        RaycastHit2D ray = Physics2D.Raycast(this.transform.position, Vector2.down, transform.localScale.y / 1.8f, whatIsGround.value);

        if (ray.collider != null)
        {
            PlayerStatus.Instance.ResetJumpStatus();
        }
        else
        {
            PlayerStatus.Instance.onGround = false;
        }
        #endregion // 바닥 채크

        transform.rotation = Quaternion.identity; // 훅 때문에 Rigidbody 에서 z 축 회전을 고정시켜도 Parent 의 영향을 받게 되서
    }


    private void ResetPhysics()
    {
        if(PlayerStatus.Instance.onHook)
        {
            PhysicsManager.Instance.SetGravity(rigid);
        }
    }

    public void Push(Vector2 normal, float amount = 1)
    {
        PhysicsManager.Instance.PushObj(rigid, normal, amount);
    }
}

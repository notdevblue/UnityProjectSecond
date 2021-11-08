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
            ResetPhysics();

            if (PlayerStatus.Instance.moveable)
            {
                transform.position += Vector3.left * PlayerStats.Instance.speed * Time.deltaTime;
                PlayerStatus.Instance.isMoving = true;
            }
        };

        InputHandler.Instance.OnKeyRight += () =>
        {
            ResetPhysics();

            if (PlayerStatus.Instance.moveable)
            {
                transform.position += Vector3.right * PlayerStats.Instance.speed * Time.deltaTime;
                PlayerStatus.Instance.isMoving = true;
            }
        };

        // Jump
        InputHandler.Instance.OnKeyJump += () =>
        {
            ResetPhysics();

            if (PlayerStatus.Instance.jumpable)
            {
                if (!PlayerStatus.Instance.isJumping && PlayerStatus.Instance.onGround)
                {
                    PlayerStatus.Instance.isJumping = true;
                    PlayerStatus.Instance.onGround = false;
                }
                else
                {
                    PlayerStatus.Instance.isDoubleJumping = true;
                    PlayerStatus.Instance.jumpable = false;
                    rigid.velocity = rigid.velocity * Vector2.right;
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

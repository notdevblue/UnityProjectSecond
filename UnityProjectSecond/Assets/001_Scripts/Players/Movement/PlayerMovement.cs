using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid = null;

    [SerializeField] LayerMask whatIsGround;

    private void Awake()
    {
        rigid  = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // Movement
        InputHandler.Instance.OnKeyLeft += () =>
        {
            ResetPhysics();

            if (PlayerStatus.Instance.moveable)
            {
                // rigid.AddForce(Vector2.left * PlayerStats.Instance.speed * Time.deltaTime, ForceMode2D.Impulse);
                transform.position += Vector3.left * PlayerStats.Instance.speed * Time.deltaTime;
                PlayerStatus.Instance.isMoving = true;
            }
        };

        InputHandler.Instance.OnKeyRight += () =>
        {
            ResetPhysics();

            if (PlayerStatus.Instance.moveable)
            {
                // rigid.AddForce(Vector2.right * PlayerStats.Instance.speed * Time.deltaTime, ForceMode2D.Impulse);
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
            OnGround();
        }
        else
        {
            PlayerStatus.Instance.onGround = false;
        }
        #endregion // 바닥 채크
    }

    /// <summary>
    /// 바닥에 닿았을 때 실행됨
    /// </summary>
    private void OnGround()
    {
        PlayerStatus.Instance.onGround = true;
        PlayerStatus.Instance.jumpable = true;
        PlayerStatus.Instance.isJumping = false;
        PlayerStatus.Instance.isDoubleJumping = false;
    }
    #warning 잘못된 코드 위치. 따로 나누어야 함, 훜 걸었을 때 실행해야 함


    private void ResetPhysics()
    {
        if(PlayerStatus.Instance.onHook)
        {
            PhysicsManager.Instance.SetGravity(rigid);
        }
    }
}

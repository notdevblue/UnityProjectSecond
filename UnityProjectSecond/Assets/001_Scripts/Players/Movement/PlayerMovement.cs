using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid = null;
    private PlayerStatus status = null;

    [SerializeField] LayerMask whatIsGround;

    private void Awake()
    {
        rigid  = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
    }

    private void Start()
    {
        // Movement
        InputHandler.Instance.OnKeyLeft += () =>
        {
            if (status.moveable)
            {
                // rigid.AddForce(Vector2.left * PlayerStats.Instance.speed * Time.deltaTime, ForceMode2D.Impulse);
                transform.position += Vector3.left * PlayerStats.Instance.speed * Time.deltaTime;
                status.isMoving = true;
            }
        };

        InputHandler.Instance.OnKeyRight += () =>
        {
            if (status.moveable)
            {
                // rigid.AddForce(Vector2.right * PlayerStats.Instance.speed * Time.deltaTime, ForceMode2D.Impulse);
                transform.position += Vector3.right * PlayerStats.Instance.speed * Time.deltaTime;
                status.isMoving = true;
            }
        };

        // Jump
        InputHandler.Instance.OnKeyJump += () =>
        {
            if (status.jumpable)
            {
                if (!status.isJumping && status.onGround)
                {
                    status.isJumping = true;
                    status.onGround = false;
                }
                else
                {
                    status.isDoubleJumping = true;
                    status.jumpable = false;
                    rigid.velocity = rigid.velocity * Vector2.right;
                }

                rigid.AddForce(Vector2.up * PlayerStats.Instance.jumpForce, ForceMode2D.Impulse);
            }
        };

        InputHandler.Instance.OnIdle += () =>
        {
            status.isMoving = false;
        };
    } // start() end

    private void Update()
    {
        #region 바닥 채크
        RaycastHit2D ray = Physics2D.Raycast(this.transform.position, Vector2.down, transform.localScale.y / 1.8f, whatIsGround.value);

        if (ray.collider != null)
        {
            status.onGround = true;
            status.jumpable = true;
            status.isJumping = false;
            status.isDoubleJumping = false;
        }
        else
        {
            status.onGround = false;
        }
        #endregion // 바닥 채크
    }
}

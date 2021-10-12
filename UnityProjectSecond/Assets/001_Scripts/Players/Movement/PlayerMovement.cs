using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid = null;
    private PlayerStatus status = null;

    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float jumpForce = 5.0f;

    private void Awake()
    {
        rigid  = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
    }

    private void Start()
    {
        // Movement
        InputHandler.Instance.OnKeyLeft += () => {
            if(status.moveable)
            {
                // rigid.AddForce(Vector2.left * speed * Time.deltaTime, ForceMode2D.Impulse);
                transform.position += Vector3.left * speed * Time.deltaTime;
                status.isMoving = true;
            }
        };

        InputHandler.Instance.OnKeyRight += () => {
            if(status.moveable)
            {
                // rigid.AddForce(Vector2.right * speed * Time.deltaTime, ForceMode2D.Impulse);
                transform.position += Vector3.right * speed * Time.deltaTime;
                status.isMoving = true;
            }
        };


        // Jump
        InputHandler.Instance.OnKeyJump += () => {
            if(status.jumpable)
            {
                if (!status.isJumping)
                {
                    status.isJumping = true;
                    status.onGround  = false;
                }
                else
                {
                    status.isDoubleJumping = true;
                    status.jumpable        = false;
                    rigid.velocity = rigid.velocity * Vector2.right;
                }

                rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        };

        InputHandler.Instance.OnIdle += () => {
            status.isMoving = false;
        };
    }


    private void OnCollisionEnter2D(Collision2D other) // 바닥 체크
    {
        if(other.gameObject.CompareTag("GROUND"))
        {
            status.onGround        = true;
            status.jumpable        = true;
            status.isJumping       = false;
            status.isDoubleJumping = false;
        }    
    }
}

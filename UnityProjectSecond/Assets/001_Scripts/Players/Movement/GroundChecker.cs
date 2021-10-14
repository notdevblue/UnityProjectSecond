using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private PlayerStatus status = null;

    private void Awake()
    {
        status = transform.parent.GetComponent<PlayerStatus>();
    }

    private void OnCollisionEnter2D(Collision2D other) // 바닥 체크
    {
        Debug.Log("와 센즈");
        if (other.gameObject.CompareTag("GROUND"))
        {
            status.onGround = true;
            status.jumpable = true;
            status.isJumping = false;
            status.isDoubleJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GROUND"))
        {
            status.onGround = false;
        }
    }
}

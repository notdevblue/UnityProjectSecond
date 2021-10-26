using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) // 바닥 체크
    {
        if (other.gameObject.CompareTag("GROUND"))
        {
            PlayerStatus.Instance.onGround = true;
            PlayerStatus.Instance.jumpable = true;
            PlayerStatus.Instance.isJumping = false;
            PlayerStatus.Instance.isDoubleJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GROUND"))
        {
            PlayerStatus.Instance.onGround = false;
        }
    }
}

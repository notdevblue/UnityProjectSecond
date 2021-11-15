using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class ToBossBattle : MonoBehaviour
{
    // 호출되면 BossBattle 의미
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PLAYER"))
        {
            GameManager.Instance.OnBossBattle = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AIAttack : MonoBehaviour
{

    const string PLAYER = "PLAYER";

    abstract protected void Attack(Collision2D other);

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag(PLAYER))
        {
            Attack(other);
        }
    }
}

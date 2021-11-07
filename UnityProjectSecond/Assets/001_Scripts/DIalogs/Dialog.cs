using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    const string PLAYER = "PLAYER";

    [SerializeField] private int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER))
        {
            DialogManager.Instance.Show(id);
            gameObject.SetActive(false); // 재생 후 삭제
        }
    }
}

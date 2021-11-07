using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField] private int id;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // show dialog
        DialogManager.Instance.Show(id);
    }
}

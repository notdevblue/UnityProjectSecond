using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    [SerializeField] private GameObject  cursor         = null;
                     private ISelectable selectedObject = null; // 선택된 오브젝트

    const string SELECTABLE = "SELECTABLE";


    private void Start()
    {
        InputHandler.Instance.OnKeyAttack += () => {
            selectedObject?.Selected();
        };
    }

    private void FixedUpdate()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0.0f;
        cursor.transform.position = pos;
    }

    // 선택
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.CompareTag(SELECTABLE))
        {
            selectedObject = other.transform.GetComponent<ISelectable>();
            selectedObject?.Focus();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag(SELECTABLE))
        {
            selectedObject?.DeFocus();
            selectedObject = null;
        }
    }
}

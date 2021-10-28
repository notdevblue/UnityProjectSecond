using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class SelectManager : MonoBehaviour
{
    [SerializeField] private GameObject  cursor         = null;
    [SerializeField] private GameObject  selectIcon = null;     // 선택 아이콘
                     private Selectable  selectedObject = null; // 선택된 오브젝트

    const string SELECTABLE = "SELECTABLE";


    private void Start()
    {
        selectIcon.SetActive(false);

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
            selectedObject = other.transform.GetComponent<Selectable>();
            if(selectedObject != null)
            {
                selectedObject.Focus();
                selectIcon.SetActive(true);
                selectedObject.SetSelectIconTransform(selectIcon.transform);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag(SELECTABLE))
        {
            selectedObject?.DeFocus();
            selectedObject = null;
            selectIcon.SetActive(false);
        }
    }
}

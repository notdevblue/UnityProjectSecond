using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Dialog : MonoBehaviour
{
    const string PLAYER = "PLAYER";

    public bool doNotDisable = false; // 꺼지면 안되는 다이얼로그 용도
    [SerializeField] private int id;

    private bool isActivated = false;

    private IDialogCallback callback = null;

    private void Awake()
    {
        callback = GetComponentInChildren<IDialogCallback>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(PLAYER) && !isActivated)
        {
            isActivated = true; // 두번 호출되는 버그 방지

            DialogManager.Instance.Show(id, () => {
                isActivated = false;
                callback?.Callback(); // 닫힌 후 실행하는 함수
            });
            gameObject.SetActive(doNotDisable); // 재생 후 삭제
        }
    }
}

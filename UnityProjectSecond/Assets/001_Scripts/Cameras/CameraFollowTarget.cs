using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoSingleton<CameraFollowTarget>
{
    public Transform target = null; // 카메라가 따라갈 오브젝트

    [Range(0.0f, 1.0f)]
    [SerializeField] private float followAmout = 0.8f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float mouseFollowAmount = 0.8f;

    private float defaultMouseFollowAmount = 0.0f; // 따라가면 안되는 일이 있음

    private void Awake()
    {
        defaultMouseFollowAmount = mouseFollowAmount;
    }

    void FixedUpdate()
    {
        Vector3 mousePos  = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        Vector3 firstLerp = Vector3.Lerp(transform.position, target.position, followAmout);
        Vector3 pos       = Vector3.Lerp(firstLerp, mousePos, mouseFollowAmount);
                pos.z     = -10;

        transform.position = pos;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    /// <summary>
    /// 마우스 추적을 비활성화합니다.
    /// </summary>
    public void DisableMouseFollow()
    {
        mouseFollowAmount = 0.0f;
    }

    /// <summary>
    /// 마우스 추적을 활성화합니다.
    /// </summary>
    public void EnableMouseFollow()
    {
        mouseFollowAmount = defaultMouseFollowAmount;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoSingleton<CameraFollowTarget>
{
    public Transform target = null; // 카메라가 따라갈 오브젝트
    [SerializeField] private float followAmout = 0.8f; // 0 ~ 1

    void Update()
    {
        Vector3 pos = Vector3.Lerp(transform.position, target.position, followAmout);
        pos.z = -10;
        transform.position = pos;
    }
}

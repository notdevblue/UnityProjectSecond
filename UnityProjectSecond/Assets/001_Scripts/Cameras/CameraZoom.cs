using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoSingleton<CameraZoom>
{
    [SerializeField] float minSize = 30.0f; // 최소 FoV
    [SerializeField] float defaultSize = 50.0f; // 기본 FoV
    [SerializeField] float maxSize = 70.0f; // 최대 FoV

    [SerializeField] float decraseStep = 0.5f; // 카메라 FoV

    public bool CanZoom { get; set; } // 줌 상태

    void Start()
    {
        CanZoom = true;

        InputHandler.Instance.OnMouseWheel += y => { // 휠 입력 따라 시아 조절
            if (CanZoom)
            {
                float value = Camera.main.fieldOfView - y * decraseStep;
                Camera.main.fieldOfView = Mathf.Clamp(value, minSize, maxSize);
            }
        };
    }

    /// <summary>
    /// 시아를 설정합니다.
    /// </summary>
    /// <param name="fov">시아 범위</param>
    public void SetFoV(float fov)
    {
        Camera.main.fieldOfView = fov;
    }

}

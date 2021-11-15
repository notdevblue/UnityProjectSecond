using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoSingleton<CameraZoom>
{
    [SerializeField] float minSize = 30.0f;
    [SerializeField] float defaultSize = 50.0f;
    [SerializeField] float maxSize = 70.0f;

    [SerializeField] float decraseStep = 0.5f;

    public bool CanZoom { get; set; }

    void Start()
    {
        InputHandler.Instance.OnMouseWheel += y => {
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

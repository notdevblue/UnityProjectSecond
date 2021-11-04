using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] float minSize = 30.0f;
    [SerializeField] float defaultSize = 50.0f;
    [SerializeField] float maxSize = 70.0f;

    [SerializeField] float decraseStep = 0.5f;


    void Start()
    {
        InputHandler.Instance.OnMouseWheel += y => {
            float value = Camera.main.fieldOfView - y * decraseStep;
            Camera.main.fieldOfView = Mathf.Clamp(value, minSize, maxSize);
        };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] float minSize = 3.0f;
    [SerializeField] float defaultSize = 5.0f;
    [SerializeField] float maxSize = 7.0f;

    [SerializeField] float decraseStep = 0.5f;


    void Start()
    {
        InputHandler.Instance.OnMouseWheel += y => {
            float value = Camera.main.orthographicSize - y * decraseStep;
            Camera.main.orthographicSize = Mathf.Clamp(value, minSize, maxSize);
        };
    }
}

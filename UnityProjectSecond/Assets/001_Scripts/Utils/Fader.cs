using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fader : MonoBehaviour
{
    CanvasGroup canvasGroup;

    [SerializeField] private float speed = 1.5f;


    private void Awake() {
        GetComponent<CanvasGroup>().alpha = 1.0f;
        GetComponent<CanvasGroup>().DOFade(0.0f, speed).SetEase(Ease.OutCubic);
    }
}

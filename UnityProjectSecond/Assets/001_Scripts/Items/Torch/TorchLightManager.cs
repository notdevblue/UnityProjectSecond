using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class TorchLightManager : MonoBehaviour
{
    public float defaultLightIntensity = 1.0f;
    public float lightFlickerRange = 0.2f;

    public float flickerDelay = 1.0f; // intencity 변화 딜레이 시간



    private Light2D torchLight = null;
    private float flickedTime = float.MinValue;
    private float targetIntensity;

    private readonly float lerpAmount = 0.05f;



    private void Start()
    {
        torchLight = GetComponentInChildren<Light2D>();
    }

    private void Update()
    {
        if(flickedTime + flickerDelay < Time.time) // 불 깜빡임 설정
        {
            flickedTime = Time.time;
            targetIntensity = Random.Range(defaultLightIntensity - lightFlickerRange, defaultLightIntensity + lightFlickerRange);
        }

        torchLight.intensity = Mathf.Lerp(torchLight.intensity, targetIntensity, lerpAmount);
    }


}

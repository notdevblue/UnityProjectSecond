using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용 안하는 코드

public class TimeManager : MonoBehaviour
{
    public GameObject[] stages = new GameObject[2]; // 일단 두개

    private void Awake()
    {
        stages[0].SetActive(false);
        stages[1].SetActive(true);
    }

    void Start()
    {
        InputHandler.Instance.OnKeyTime += () => {
            stages[0].SetActive(!stages[0].activeSelf);
            stages[1].SetActive(!stages[1].activeSelf);
        };
    }
}

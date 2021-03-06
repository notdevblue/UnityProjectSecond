using UnityEngine;
using System.Collections.Generic;

public class SlimePoolManager : MonoSingleton<SlimePoolManager>
{
    [SerializeField] private GameObject slimePrefab = null;
    [SerializeField] private int slimeInitCount = 10;

    private List<GameObject> pool = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < slimeInitCount; ++i)
        {
            pool.Add(Create());
        }
    }

    private GameObject Create()
    {
        GameObject temp = Instantiate(slimePrefab, transform);
        temp.SetActive(false);
        return temp;
    }

    /// <summary>
    /// 슬라임을 하나 가져옵니다.
    /// </summary>
    public GameObject Get(Vector2? pos = null)
    {
        GameObject temp = pool.Find(e => !e.activeSelf);
        
        if(temp == null)
        {
            temp = Create();
            pool.Add(temp);
        }

        if(pos != null) // 위치 지정한 경우
        {
            temp.transform.position = (Vector2)pos;
        }

        temp.SetActive(true);

        return temp;
    }
}
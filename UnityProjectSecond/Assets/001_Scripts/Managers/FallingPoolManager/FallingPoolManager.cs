using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPoolManager : MonoSingleton<FallingPoolManager>
{
    [SerializeField] private GameObject[] objList = new GameObject[0];
    [SerializeField] private int objPerInitCount = 5;

    /// <summary>
    /// [i] = objType, [j] = obj
    /// </summary>
    private List<List<GameObject>> pool = new List<List<GameObject>>();

    private void Awake()
    {
        for (int i = 0; i < objList.Length; ++i)
        {
            pool.Add(new List<GameObject>());
            for (int j = 0; j < objPerInitCount; ++j)
            {
                pool[i].Add(CreateNewObject(objList[i]));
            }
        }
    }

    private GameObject CreateNewObject(GameObject what)
    {
        GameObject temp = Instantiate(what, transform);
        temp.SetActive(false);
        return temp;
    }

    /// <summary>
    /// 낙하 오브젝트를 하나 가져옵니다.
    /// </summary>
    /// <param name="pos">생성할 위치</param>
    /// <param name="objIndex">원하는 낙하물 Index</param>
    /// <returns>낙하물 GameObject</returns>
    public GameObject Get(Vector2 pos = default(Vector2), int objIndex = -1)
    {
        int        index = objIndex == -1 ? Random.Range(0, objList.Length - 1) : objIndex; // 특정한 Object 를 요청한 경우
        GameObject temp  = pool[index].Find(e => !e.activeSelf);

        if(temp == null)
        {
            temp = CreateNewObject(objList[index]);
            pool[index].Add(temp);   
        }

        if(pos != default(Vector2)) // 만약 위치를 지정한 경우
        {
            temp.transform.position = pos;
        }

        temp.SetActive(true);

        return temp;
    }


}

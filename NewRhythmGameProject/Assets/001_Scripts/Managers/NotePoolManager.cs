using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePoolManager : MonoSingleton<NotePoolManager>
{
    [SerializeField] private GameObject note;
    private List<GameObject> notePool = new List<GameObject>();

    private void Awake()
    {
        InitPool();
    }

    private void InitPool()
    {
        for (int i = 0; i < 60; ++i)
        {
            notePool.Add(AddObject());
        }
    }

    private GameObject AddObject()
    {
        GameObject temp = Instantiate(note, this.transform);
        temp.SetActive(false);
        return temp;
    }


    public GameObject Get()
    {
        GameObject obj = notePool.Find(x => !x.activeSelf);
        if(obj == null)
        {
            obj = AddObject();
            notePool.Add(obj);
        }

        obj.SetActive(true);
        return obj;
    }

}

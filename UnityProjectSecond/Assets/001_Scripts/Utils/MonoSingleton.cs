using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static public T Instance { get; private set; }

    protected virtual void Awake()
    {
        T[] objs = FindObjectsOfType<T>();
        
        if(objs.Length > 0)
        {
            Instance = objs[0];
        }

        if(objs.Length > 1)
        {
            Debug.LogWarning($"There are more than one {Instance.GetType()} Running at same scene.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static private T _instance;
    static public T Instance
    {
        get
        {
            if(_instance == null)
            {
                T[] objs = FindObjectsOfType<T>();

                if (objs.Length > 0)
                {
                    _instance = objs[0];
                }

                if (objs.Length > 1)
                {
                    Debug.LogWarning($"There are more than one {Instance.GetType()} Running at same scene.");
                }
            }

            return _instance;
        }
    }
}

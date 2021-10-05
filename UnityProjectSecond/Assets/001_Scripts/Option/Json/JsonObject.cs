using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class JsonObject
{
    public virtual void OverrideData(string json)
    {
        try
        {
            JsonUtility.FromJsonOverwrite(json, this);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"{this.GetType()}: Cannot Load Settings. Reverting to default.\r\n{e}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>this as Json string</returns>
    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }
}

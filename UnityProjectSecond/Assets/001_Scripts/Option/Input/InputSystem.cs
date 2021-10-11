using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    static public InputSystem Instance { get; private set; }

    public OptionInput Input { get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There are more than one InputSystem running at same scene. Destroying.");
            Debug.LogWarning($"Attached GamObject: {gameObject.name}");
            Destroy(this);
        }
        Instance = this;

        Input = new OptionInput();

        SetJsonData(Input);
    }

    private void Update()
    {

    }


    /// <summary>
    /// JSON 을 읽고 Override 함
    /// </summary>
    /// <param name="obj">Override 할 Class</param>
    private void SetJsonData<T>(T obj) where T : JsonObject
    {
        string data = JsonFileManager.Read(obj.GetType().ToString());

        if (data == null)
        {
            JsonFileManager.Write(obj.GetType().ToString(), obj.ToString());
            data = JsonFileManager.Read(obj.GetType().ToString());
        }

        Debug.Log("Loaded: " + data);
        obj.OverrideData(data);
    }


}

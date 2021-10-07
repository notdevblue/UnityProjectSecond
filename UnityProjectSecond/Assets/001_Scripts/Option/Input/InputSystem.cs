using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    private OptionInput input = new OptionInput();


    private void Awake()
    {
        string data = JsonFileManager.Read(input.GetType().ToString());

        if(data == null)
        {
            JsonFileManager.Write(input.GetType().ToString(), input.ToString());
            data = JsonFileManager.Read(input.GetType().ToString());
        }
        Debug.Log("Data: " + data);
        input.OverrideData(data);

        // TODO : 따로 함수로 뺴둬야 함
    }


}

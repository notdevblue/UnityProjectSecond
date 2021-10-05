using System.IO;
using UnityEngine;

public class JsonFileManager : MonoBehaviour
{
    /// <summary>
    /// Reads json data from path/options/optionType
    /// </summary>
    /// <param name="optionType">Option name</param>
    /// <returns>Json Data, null when there is no file</returns>
    static public string Read(string optionType)
    {
        if(!File.Exists($"{Application.persistentDataPath}/options/{optionType}"))
        {
            return null;
        }

        return File.ReadAllText($"{Application.persistentDataPath}/options/{optionType}");
    }

    static public void Write(string optionType, string json)
    {
        if(!File.Exists($"{Application.persistentDataPath}/options/{optionType}"))
        {

        }


        using (StreamWriter outputFile = new StreamWriter($"{Application.persistentDataPath}/options/{optionType}"))
        {
            outputFile.WriteLine(json);
            Debug.Log("Saved at : " + Application.persistentDataPath);
        }
    }
}

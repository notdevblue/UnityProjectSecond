using System.IO;
using UnityEngine;

public class JsonFileManager : MonoBehaviour
{
    /// <summary>
    /// Reads json data from path/Data/fileName
    /// </summary>
    /// <param name="fileName">filename</param>
    /// <returns>Json Data, null when there is no file</returns>
    static public string Read(string fileName)
    {
        if(!File.Exists($"{Application.persistentDataPath}/Data/{fileName}")) // 파일 존제 채크
        {
            return null;
        }

        return File.ReadAllText($"{Application.persistentDataPath}/Data/{fileName}");
    }

    static public void Write(string fileName, string json)
    {
        if (!File.Exists($"{Application.persistentDataPath}/Data/{fileName}")) // 파일 존제 안할 시 파일 생성
        {
            Directory.CreateDirectory($"{Application.persistentDataPath}/Data/"); // mkdir
            File.Create($"{Application.persistentDataPath}/Data/{fileName}").Close(); // touch
            Debug.Log("Created folder at: " + Application.persistentDataPath + "/Data/"); // nvim
        }


        StreamWriter outputFile = new StreamWriter($"{Application.persistentDataPath}/Data/{fileName}"); // 파일에 작성
        outputFile.WriteLine(json);
        Debug.Log("Saved at : " + Application.persistentDataPath);
        outputFile.Close();
    }
}

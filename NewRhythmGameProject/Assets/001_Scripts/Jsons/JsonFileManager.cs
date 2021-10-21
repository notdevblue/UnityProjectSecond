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
        string destPath = Path.Combine(Application.persistentDataPath, "Data", fileName);

        if(!File.Exists(destPath)) // 파일 존제 채크
        {
            return null;
        }

        return File.ReadAllText(destPath);
    }

    /// <summary>
    /// Reads json data from path
    /// </summary>
    /// <param name="path">path</param>
    /// <param name="fileName">filename</param>
    /// <returns>Json Data, null when there is no file</returns>
    static public string Read(string fileName, string path)
    {
        string destPath = Path.Combine(path, fileName);

        if (!File.Exists(destPath)) // 파일 존제 채크
        {
            return null;
        }

        return File.ReadAllText(destPath);
    }

    static public void Write(string fileName, string json)
    {
        string destPath = Path.Combine(Application.persistentDataPath, "Data", fileName);
        if (!File.Exists(destPath)) // 파일 존제 안할 시 파일 생성
        {
            Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Data")); // mkdir
            File.Create(destPath).Close(); // touch
            Debug.Log("Created folder at: " + Path.Combine(Application.persistentDataPath, "Data")); // nvim
        }


        StreamWriter outputFile = new StreamWriter(destPath); // 파일에 작성
        outputFile.WriteLine(json);
        Debug.Log("Saved at : " + Application.persistentDataPath);
        outputFile.Close();
    }

    static public void Write(string fileName, string path, string json)
    {
        string destPath = Path.Combine(path, fileName);

        if (!File.Exists(path)) // 파일 존제 안할 시 파일 생성
        {
            Directory.CreateDirectory(path); // mkdir
            File.Create(destPath).Close(); // touch
            Debug.Log("Created folder at: " + destPath); // nvim
        }


        StreamWriter outputFile = new StreamWriter(destPath); // 파일에 작성
        outputFile.WriteLine(json);
        Debug.Log("Saved at : " + destPath);
        outputFile.Close();
    }


    static public string Combine(params string[] paths)
    {
        return Path.Combine(paths);
    }
}

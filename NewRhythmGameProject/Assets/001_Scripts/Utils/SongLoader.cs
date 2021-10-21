using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class SongLoader : MonoBehaviour
{
    public SpriteRenderer sr;
    public Image bg;


#warning DEBUG CODE. MUST FIX
    static public string songJson;

    private void Awake()
    {
        Read();
    }


    private void Read()
    {
        // 현제 경로
        Debug.Log($"pwd > {Directory.GetCurrentDirectory()}"); // pwd

        // ./Songs 폴더 안에 있는 폴더의 경로를 전부 가져옴
        string[] path = Directory.GetDirectories("./Songs"); // ls


        for (int i = 0; i < path.Length; ++i)
        {
            // 레벨 확인
            if (Directory.Exists(Path.Combine(path[i] ,"Levels")))
            {
                for (int j = 1; j <= 3; ++j)
                {
                    string levelPath = Path.Combine(path[i], "Levels", $"Difficulty{j}.json");
                    if (!File.Exists(levelPath))
                    {
                        continue;
                    }
                    string levelJson = File.ReadAllText(levelPath);

                    Debug.Log($"Level{j} > {levelJson}");

#warning DEBUG CODE. MUST FIX
                    songJson = levelJson;


                    // TODO : 불러온 파일들 어딘가에다가 놔 두어야 함
                }
            }
            else
            {
                Debug.LogWarning($"Folder Index: {i + 1}, dir: {path[i]} > No level folder found. Skipping");
                continue;
            }

            if(File.Exists(Path.Combine(path[i], "icon.png")))
            {
                sr?.sprite.texture.LoadImage(File.ReadAllBytes(Path.Combine(path[i], "icon.png")));
                Debug.Log("Loaded Icon");
            }
            if(File.Exists(Path.Combine(path[i], "background.png")))
            {
                bg?.GetComponent<Image>().sprite.texture.LoadImage(File.ReadAllBytes(Path.Combine(path[i], "background.png")));
                // bg.GetComponent<Image>().sprite.texture.Resize(Screen.currentResolution.width, Screen.currentResolution.height); // not readable
                Debug.Log("Loaded Background");
            }
            

            
        }
    }

    // public static void SetTextureImporterFormat(Texture2D texture, bool isReadable)
    // {
    //     if (null == texture) return;

    //     string assetPath = AssetDatabase.GetAssetPath(texture);
    //     var tImporter = AssetImporter.GetAtPath(assetPath) as TextureImporter;
    //     if (tImporter != null)
    //     {
    //         tImporter.textureType = TextureImporterType.Default;

    //         tImporter.isReadable = isReadable;

    //         AssetDatabase.ImportAsset(assetPath);
    //         AssetDatabase.Refresh();
    //     }
    // }
}

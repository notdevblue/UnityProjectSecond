using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongLoader : MonoBehaviour
{
    public SpriteRenderer sr;
    public Image bg;


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
            // 파일 확인
            if(File.Exists($"{path[i]}/icon.png"))
            {
                sr.sprite.texture.LoadImage(File.ReadAllBytes($"{path[i]}/icon.png"));
                Debug.Log("Loaded Icon");
            }
            if(File.Exists($"{path[i]}/background.png"))
            {
                // Texture2D texture = new Texture2D(1, 1);
                // texture.LoadImage(File.ReadAllBytes($"{path[i]}/background.png"));
                // bg.sprite.texture.LoadImage(File.ReadAllBytes($"{path[i]}/background.png")); not working
                bg.sprite.texture.LoadImage(File.ReadAllBytes($"{path[i]}/background.png")); // 텍스쳐 화질 문제
                Debug.Log("Loaded Background");
            }

            
        }


        // foreach (string p in path)
        // {
        //     Debug.Log(p); // 폴더 안에 있는 것의 상대경로
        // }



    }
}

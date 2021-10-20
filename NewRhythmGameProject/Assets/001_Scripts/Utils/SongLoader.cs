using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongLoader : MonoBehaviour
{

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
                Texture2D texture;
                texture = new Texture2D(0, 0);
                texture.LoadImage(System.IO.File.ReadAllBytes($"{path[i]}/icon.png"));

            }
            File.Exists($"{path[i]}/background.png");

            
        }


        // foreach (string p in path)
        // {
        //     Debug.Log(p); // 폴더 안에 있는 것의 상대경로
        // }



    }
}

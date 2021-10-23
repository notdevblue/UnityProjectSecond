using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class SongLoader : MonoSingleton<SongLoader>
{
    #if UNITY_STANDALONE_LINUX
    const string MOVIE = "video.webm";
#else
    const string MOVIE = "video.mp4";
#endif
    const string AUDIO = "music.mp3";
    const string BACKGROUND = "background.png";
    const string ICON = "icon.png";
    const string INGAMEINFO = "ingameinfo.json";
    const string TITLEINFO = "titleinfo.json";
    const string DIFFICULTY = "Difficulty";
    const string LEVELS_FOLDER = "Levels";
    const string SONGS_FOLDER = "Songs";


    private int index = 0; // 곡 갯수
    public VideoPlayer video; // 비디오 로드 위함

    // 곡 데이터를 가진 List
    private List<SongJson> songDataList = new List<SongJson>();

    private void Awake()
    {
        // video = GetComponent<VideoPlayer>();
        if(video == null)
        {
            Debug.LogError("SongLoader > Cannot find VideoPlayer");
            enabled = false;
            return;
        }

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        
        StartCoroutine(Read(() => {
            
            // TODO : Change scene?
        }));
    }



    IEnumerator Read(Action callback = null)
    {
        // ./Songs 폴더 안에 있는 폴더의 경로를 전부 가져옴
        string[] path = Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), SONGS_FOLDER)); // ls

        // Songs 안 폴더 전부 확인
        for (int i = 0; i < path.Length; ++i)
        {
            #region 폴더 확인과 레벨과 곡 존재 확인
            if (!Directory.Exists(Path.Combine(path[i], LEVELS_FOLDER)) || Directory.GetFiles(Path.Combine(path[i], LEVELS_FOLDER)).Length == 0) // 레벨 확인
            {
                Debug.LogWarning($"{path[i]} > No levels found.");
                continue;
            }
            if (!File.Exists(Path.Combine(path[i], AUDIO))) // 곡 확인
            {
                Debug.LogWarning($"{path[i]} > No song found");
                continue;
            }

            #endregion

            Nullable<bool> result = null;     // WaitUntil 때문에 Nullable<bool> 로 선언
            songDataList.Add(new SongJson()); // 곡 하나 추가

            // 레벨 로드
            for (int j = 1; j <= 3; ++j)
            {
                string levelPath = Path.Combine(path[i], LEVELS_FOLDER, $"{DIFFICULTY}{j}.json");
                if (!File.Exists(levelPath))
                {
                    continue;
                }
                string levelJson = File.ReadAllText(levelPath);

                songDataList[index].Add(levelJson, j - 1);
                Debug.Log($"{path[i]} > Loaded level {j}.");
            }

            // 아이콘 로드
            if (File.Exists(Path.Combine(path[i], ICON)))
            {
                // sr?.sprite.texture.LoadImage(File.ReadAllBytes(Path.Combine(path[i], ICON)));
                Debug.Log("nLoaded Icon");
            }

            // 뒷 배경 로드?
            if (File.Exists(Path.Combine(path[i], BACKGROUND)))
            {
                // bg?.GetComponent<Image>().sprite.texture.LoadImage(File.ReadAllBytes(Path.Combine(path[i], BACKGROUND)));
                // bg.GetComponent<Image>().sprite.texture.Resize(Screen.currentResolution.width, Screen.currentResolution.height); // not readable
                Debug.Log("nLoaded Background");
            }

            // 비디오 로드
            if (File.Exists(Path.Combine(path[i], MOVIE)))
            {
                video.url = $"{path[i]}/{MOVIE}";
                songDataList[index].Add(video.clip);
                video.Play();

                Debug.Log($"{path[i]} > Loaded Video.");
            }

            // 곡 로드
            if (File.Exists(Path.Combine(path[i], AUDIO)))
            {
                StartCoroutine(RequestAudio(path[i], res => result = res));

                yield return new WaitUntil(() => result != null);
                if(result == false)
                {
                    songDataList.RemoveAt(index);
                    continue; // 이거 때문에 함수화 안 함
                }
                Debug.Log($"{path[i]} > Loaded Music.");
                result = null;
            }

            ++index;
        } // for(int i = 0; i < path.Length; ++i) end
    }



    /// <summary>
    /// 곡을 가져오는 Coroutine
    /// </summary>
    /// <param name="path">경로</param>
    /// <param name="result">성공 여부를 매개 변수로 전달하는 Action</param>
    IEnumerator RequestAudio(string path, Action<bool> result)
    {
        using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip($"file:///{path}/{AUDIO}", AudioType.MPEG))
        {
            yield return req.SendWebRequest();

            if(req.result == UnityWebRequest.Result.Success)
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
                songDataList[index].Add(clip);
                result(true);
            }
            else
            {
                Debug.LogError("Failed to load song.");
                result(false);
            }
        }
    }

#region 외부 공개 함수
    /// <summary>
    /// 곡을 가져옵니다.
    /// </summary>
    /// <param name="idx">해당하는 인덱스</param>
    public SongJson GetSong(int idx)
    {
        return songDataList[idx];
    }

    /// <summary>
    /// 곡 갯수를 가져옵니다.
    /// </summary>
    public int GetCount()
    {
        return index;
    }
#endregion

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

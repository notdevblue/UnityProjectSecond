using UnityEngine;
using UnityEngine.Video;

public class SongJson
{
    public string[] levels = new string[3];
    public string ingameinfo;
    public string titleinfo;
    public AudioClip song;
    public VideoClip video;

    /// <summary>
    /// 레벨을 저장합니다.
    /// </summary>
    /// <param name="level">Json</param>
    /// <param name="idx">레벨</param>
    public void Add(string level, int idx)
    {
        levels[idx] = level;
    }

    /// <summary>
    /// 곡 정보를 저장합니다.
    /// </summary>
    public void Add(string ingameinfo, string titleinfo)
    {
        this.ingameinfo = ingameinfo;
        this.titleinfo = titleinfo;
    }

    /// <summary>
    /// 곡을 저장합니다.
    /// </summary>
    public void Add(AudioClip clip)
    {
        this.song = clip;
    }

    /// <summary>
    /// 영상을 저장합니다.
    /// </summary>
    public void Add(VideoClip video)
    {
        this.video = video;
    }

}

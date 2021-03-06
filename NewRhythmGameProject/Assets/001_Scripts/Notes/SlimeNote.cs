using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeNote : NoteBase
{
    #warning TEST CODE
    #region TEST
    public float bpm = 120;
    List<float> debugStepSeconds = new List<float>();
    public Transform begin;
    public Transform end;


    #endregion


    /*
    4초에 입력이면,
    BPM = 120; // 4 / 4, 1초에 4분음표 2개
    120 / 60 / 0.25(박자) => 8?
    120 / 60 / 4(분음표) => 0.5

    0.5 초당 한 박자
    */


    float time = 0;

    private void OnEnable()
    {
        Init();
    }

    /// <summary>
    /// 생성 시 불러줘야 하는 함수
    /// </summary>
    public void Init()
    {
        float step = 0;
        time = 0;

        for (int i = 0; i < beatPattern.Length; ++i)
        {
            step += (float)bpm / 60.0f / (float)beatPattern[i];
            debugStepSeconds.Add(step);
        }

        BeatsToPlayer = beatPattern.Length;
        CurrentStep = 0;

        Move();
    }

    /// <summary>
    /// 라인 이동
    /// </summary>
    private void Move()
    {
        float x = Mathf.Lerp(begin.position.x, end.position.x, (float)(CurrentStep) / (BeatsToPlayer - 1.0f));
        transform.position = new Vector2(x, transform.position.y);
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >= debugStepSeconds[CurrentStep])
        {
            ++CurrentStep;

            Move();
        }
    }
}

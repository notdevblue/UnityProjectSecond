using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    /// <summary>
    /// 보스 배틀 입장 시 호출됨
    /// </summary>
    public System.Action OnBossBattleEnter;

    public GameObject player; // 플레이어 오브젝트
    
    [SerializeField] private GameObject bossBattlePos; // 카메라 위치
    
    private GameObject playerBorder; // 포지션 제한



    private void Start()
    {
        playerBorder = GameObject.FindGameObjectWithTag("BORDER");
        playerBorder?.SetActive(false);
        OnBossBattleEnter += () => { };
    }


    // 보스 배틀 중이면 알아서 카메라를 지정한 지점으로...
    private bool _onBossBattle = false;
    public bool OnBossBattle
    {
        get { return _onBossBattle; }
        set
        {
            CameraZoom.Instance.CanZoom = !value;
            playerBorder.SetActive(value);

            switch(value)
            {
                case true: // 배틀 입장
                    CameraFollowTarget.Instance.SetTarget(bossBattlePos.transform);
                    CameraFollowTarget.Instance.DisableMouseFollow();
                    CameraZoom.Instance.SetFoV(70.0f);
                    break;

                case false: // 배틀 퇴장
                    CameraFollowTarget.Instance.SetTarget(player.transform);
                    CameraFollowTarget.Instance.EnableMouseFollow();
                    break;
            }

            _onBossBattle = value;
        }
    } // OnBossBattle

}

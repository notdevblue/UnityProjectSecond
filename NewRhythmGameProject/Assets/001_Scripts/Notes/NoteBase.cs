using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class NoteBase : MonoBehaviour
{
    /// <summary>
    /// beatPattern.Length
    /// </summary>
    public int BeatsToPlayer { get; protected set; } // 플레이어에게 도달하기까지의 박자 (횟수)
    private int _curStep;
    public int CurrentStep { // 만약 입력 지점을 지나갔다면 비활성화시킴 ( 풀링을 위해 )
        get {
            return _curStep;
        }
        set {
            if (value >= BeatsToPlayer) {
                gameObject.SetActive(false);
            } else {
                _curStep = value;
            }
        }
    }

    [SerializeField] protected BeatEnum[] beatPattern = new BeatEnum[0]; // 가지는 패턴

    private void Awake()
    {
        // 박자
        // BPM => 4분음표가 1초에 나오는 수
        // BPM / 4분음표 => 4분음표가 몇 초마다 나오는지 알 수 있음
        // 현제 시간 => 마지막으로 노트가 나온 시간 + 위에 있는 연산 결과 => 새 노트
        
        // 또는 그냥 이 시간에 나오세요 하고 Json 파일에 저장할 수 있음
    }

    private void IncreaseStep()
    {
        
    }


}

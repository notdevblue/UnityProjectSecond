// AI 의 판단을 위한 VO

public class AIVO
{
    public float? weight; // 가중치
    public System.Action what;

    /// <summary>
    /// AI가 이 행동을 선택할 확률과 선택되었을때 호출할 Action.
    /// </summary>
    /// <param name="what">행동이 선택되었을때 호출할 Action</param>
    /// <param name="weight">가중치. 아무 값도 입력하지 않으면 1/n<br/>긴 한데 이거 아직 안 써요.</param>
    public AIVO(System.Action what, System.Action end = null, float? weight = null)
    {
        this.what   = what;
        this.weight = weight;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsManager : MonoSingleton<PhysicsManager>
{
    /// <summary>
    /// 물체에게 바로 힘을 적용합니다.
    /// </summary>
    /// <param name="target">힘을 적용할 오브젝트</param>
    /// <param name="dir">방향</param>
    /// <param name="velocity">힘</param>
    public void PushObj(Rigidbody2D target, Vector2 dir, float velocity)
    {
        target.AddForce(dir * velocity, ForceMode2D.Impulse);
    }

    /// <summary>
    /// 물체의 중력을 변경합니다.
    /// </summary>
    /// <param name="target">변경할 오브젝트</param>
    /// <param name="gravity">설정할 중력 값, 기본 = 3.0f</param>
    public void SetGravity(Rigidbody2D target, float gravity = 3.0f)
    {
        target.gravityScale = gravity;
    }
}
using UnityEngine;

public interface IPushable
{
    void Push(Vector2 normal, float amount = 1.0f);
}
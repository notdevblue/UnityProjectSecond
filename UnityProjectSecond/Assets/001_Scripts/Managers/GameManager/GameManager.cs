using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameObject player;

    const string PLAYER = "PLAYER";

    // 추후 HookManager?
    [HideInInspector] public HingeJoint2D curHookedHinge = null; // 지금 건 훅의 Rigid

    public HingeJoint2D PlayerHinge { get; private set; }
    public Rigidbody2D PlayerHingeRigid { get; private set; }

    public float minDistWithHook = 0.1f;
    public float maxDistWithHook = 3.0f;

    private void Awake()
    {
        PlayerHinge = player.GetComponentInChildren<HingeJoint2D>();
        PlayerHingeRigid = PlayerHinge.GetComponent<Rigidbody2D>();
    }

    public void ResetConnectedHinge()
    {
        if(curHookedHinge != null)
        {
            player.transform.SetParent(null);
            curHookedHinge.connectedBody = null;
            curHookedHinge = null;
        }
    }

    public float DistanceWithPlayer(Vector2 pos)
    {
        return Vector2.Distance(player.transform.position, pos);
    }

    public bool CanHook(Vector2 pos)
    {
        return Vector2.Distance(player.transform.position, pos) <= maxDistWithHook;
    }


}

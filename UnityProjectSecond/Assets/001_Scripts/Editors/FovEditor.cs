using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AIFov))] 
public class FovEditor : Editor
{
    // void OnSceneGUI()
    // {
    //     AIFov fov = target as AIFov;
    //     Vector2 fromAngle = fov.CirclePoint(fov.viewAngle * 0.5f);

    //     Handles.color = Color.blue;
    //     Handles.DrawSolidDisc(fov.transform.position + (Vector3)fromAngle, Vector3.forward, 0.1f);
    //     Handles.DrawWireDisc(fov.transform.position, Vector3.forward, fov.viewAngle);
    //     Handles.color = new Color(1, 1, 1, 0.2f);
    //     Handles.DrawSolidArc(fov.transform.position, Vector3.forward, fromAngle
    //                          , fov.viewAngle, fov.ViewRange);
    //     GUIStyle style = new GUIStyle();
    //     style.fontSize = 35;
    //     Handles.Label(fov.transform.position + new Vector3(0, 0.5f, 0),
    //                     fov.viewAngle.ToString(), style);


    // }
}
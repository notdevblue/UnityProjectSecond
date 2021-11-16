using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnalbeAutoSelect : MonoBehaviour, IDialogCallback
{
    public void Callback()
    {
        PlayerStatus.Instance.autoHookAble = true;
    }
}

using UnityEngine;

abstract public class Selectable : MonoBehaviour
{
    abstract public void Selected();
    abstract public void Focus();
    abstract public void DeFocus();

    public void SetSelectIconTransform(Transform icon)
    {
        icon.SetParent(this.transform);
        icon.localPosition = Vector3.up;
        icon.eulerAngles = new Vector3(0, 0, -90.0f + transform.eulerAngles.z);
    }
}
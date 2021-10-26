using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Interactable : MonoBehaviour
{
    abstract public void Interact();
    //public virtual void Interact() = 0; c++하고싶다
}

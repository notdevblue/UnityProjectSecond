using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionInputHandler : MonoBehaviour
{
    OptionInput input;


    void FixedUpdate()
    {
        if(Input.GetKey(input.right))
        {
            
        }
        if(Input.GetKey(input.left))
        {
            
        }
        if(Input.GetKeyDown(input.jump))
        {
            
        }
        if(Input.GetMouseButtonDown((int)input.atk))
        {
            
        }
    }
}

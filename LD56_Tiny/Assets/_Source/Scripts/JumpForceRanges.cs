using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpForceRanges : MonoBehaviour
{
    [SerializeField] private float[] rangeGreen;
    [SerializeField] private float[] rangeYellow;
    [SerializeField] private float[] rangeYellow2;
    [SerializeField] private float[] jumpForceValue;
    [SerializeField] private Scrollbar thisScroll;
    public float GetScrollValue()
    {
        float jumpValue = 0f; 
        float value = thisScroll.value;
        
            if(value > rangeGreen[0] && value < rangeGreen[1])
            {
                jumpValue = jumpForceValue[2];
            return jumpValue;
        }
            if(value > rangeYellow[0] && value < rangeYellow[1]) 
            {
                jumpValue = jumpForceValue[1];
            return jumpValue;
        }
            if(value > rangeYellow2[0] && value < rangeYellow2[1])
            {
                jumpValue = jumpForceValue[1];
            return jumpValue;
        }
            else
            {
                jumpValue = jumpForceValue[0];
            return jumpValue;
        }
        
        
    }
}

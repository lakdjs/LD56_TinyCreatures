using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Health 
{
    public const int StartValue = 3;
    private const int EndValue = 0;

    private int _addingScore = -1;
    public int HealthValue { get; private set; }

    public event Action<int> OnHealthChange;
    public void ResetScore()
    {
        HealthValue = EndValue;
        OnHealthChange?.Invoke(HealthValue);
    }
    public void SetUpScore()
    {
        Debug.Log("1");
        HealthValue = StartValue;
        OnHealthChange?.Invoke(HealthValue);
    }

    public void AddScore(int adding)
    {
        HealthValue += adding;
        if(HealthValue > 0)
        {
            OnHealthChange?.Invoke(HealthValue);
        }
        else if(HealthValue == 0)
        {
            Debug.Log("Die");
            OnHealthChange?.Invoke(HealthValue);
        }
       
    }
}

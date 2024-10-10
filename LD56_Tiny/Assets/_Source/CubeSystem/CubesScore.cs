using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesScore 
{
    public const int StartValue = 0;
    private const int EndValue = 0;

    private int _addingScore = -1;
    public int CubesValue { get; private set; }

    public event Action<int> OnCubesChange;
    public void ResetScore()
    {
        CubesValue = EndValue;
        OnCubesChange?.Invoke(CubesValue);
    }
    public void SetUpScore()
    {
        CubesValue = StartValue;
        PlayerPrefs.SetInt("Cubes", 0);
        OnCubesChange?.Invoke(CubesValue);
    }

    public void AddScore(int adding)
    {
        CubesValue += adding;
        OnCubesChange?.Invoke(CubesValue);
        Debug.Log(CubesValue);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeView : MonoBehaviour
{
    [SerializeField] private List<Image> CubesBars;
    private CubesScore _score;

    public void Construct(CubesScore score)
    {
        _score = score;
        _score.OnCubesChange += RefreshScoreText;
    }

    private void Start()
    {
        RefreshScoreText(PlayerPrefs.GetInt("Cubes"));
    }

    void RefreshScoreText(int curScore)
    {
        foreach (Image item in CubesBars) 
        {
            item.gameObject.SetActive(false);
        }
        CubesBars[curScore].gameObject.SetActive(true);
        Debug.Log("Right");
    }
    void OnDisable()
    {
        _score.OnCubesChange -= RefreshScoreText;
    }
}

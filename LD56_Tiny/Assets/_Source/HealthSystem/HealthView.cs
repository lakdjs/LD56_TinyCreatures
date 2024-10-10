using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private List<Image> HealthBars;
    private Health _score;

    public void Construct(Health score)
    {
        _score = score;
        _score.OnHealthChange += RefreshScoreText;
    }

    private void Start()
    {
        foreach (Image item in HealthBars) 
        {
            item.gameObject.SetActive(true);
        }

    }

    void RefreshScoreText(int curScore)
    {
        HealthBars[curScore].gameObject.SetActive(false);
    }
    void OnDisable()
    {
        _score.OnHealthChange -= RefreshScoreText;
    }
}

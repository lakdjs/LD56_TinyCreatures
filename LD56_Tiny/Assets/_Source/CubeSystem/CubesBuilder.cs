using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesBuilder : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private List<GameObject> cubes;
    [SerializeField] private int _maxIndex;

    private bool _isInRange = false;
    private int _indexOfCube = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerPrefs.GetInt("Cubes") > 0 && _indexOfCube < _maxIndex)
            {
                  cubes[_indexOfCube].SetActive(true);
                  _indexOfCube += 1;
                  PlayerPrefs.SetInt("Cubes", PlayerPrefs.GetInt("Cubes") - 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            _isInRange = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            _isInRange = false;
        }
    }
}

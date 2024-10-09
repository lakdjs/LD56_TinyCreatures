using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    [SerializeField] private GameObject worldCanvas;
    private bool _isInRange = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("Cubes", PlayerPrefs.GetInt("Cubes")+1);
            Debug.Log(PlayerPrefs.GetInt("Cubes"));
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            _isInRange = true;
            worldCanvas.SetActive(true);
        }
            
    }
    private void OnTriggerExit(Collider other)
    {
        if ((playerMask & (1 << other.gameObject.layer)) != 0)
        {
            _isInRange = false;
            worldCanvas.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderStates : MonoBehaviour
{
    private bool state1 = true;
    private bool state2 = false;
    [SerializeField] private PlayerController controller;
    [SerializeField] private LadderController ladderController;

    private void Start()
    {
        controller.enabled = true;
        ladderController.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ladder"))
        {
            state1 = !state1;
            state2 = !state2;
            controller.enabled = false;
            ladderController.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ladder"))
        {
            controller.enabled = true;
            ladderController.enabled = false;
        }
    }
}

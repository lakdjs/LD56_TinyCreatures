using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderStates : MonoBehaviour
{
    private bool state1 = true;
    private bool state2 = false;
    [SerializeField] private PlayerController controller;
    [SerializeField] private LadderController ladderController;
    [SerializeField] private Animator animator;

    private void Start()
    {
        controller.enabled = true;
        ladderController.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ladder"))
        {
            Debug.Log("Ladder");
            state1 = !state1;
            state2 = !state2;
            controller.enabled = false;
            ladderController.enabled = true;
            animator.SetBool("IsClimbing", true);
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsJumping", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ladder"))
        {
            animator.SetBool("IsClimbing", false);
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsJumping", true);
            controller.enabled = true;
            ladderController.enabled = false;
        }
    }
}

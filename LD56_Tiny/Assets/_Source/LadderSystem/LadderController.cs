using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private CharacterController characterController;
    private Vector3 moveDir = Vector3.zero;

    private void Update()
    {
        
        moveDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        moveDir = transform.TransformDirection(moveDir);
        moveDir *= speed;

        characterController.Move(moveDir * Time.deltaTime);
    }
}

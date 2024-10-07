using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _mouseSensitivity = 200f;
    [SerializeField] private List <Scrollbar>  scrollbars;
    [SerializeField] private List<JumpForceRanges> jumpForceRange;


    private CharacterController _characterController;
    private Vector3 _velocity;
    private float _verticalLookRotation;

    private Transform _cameraTransform;

    private float period = 0.1f;
    private float nextActionTime = 0.0f;

    static System.Random rand = new System.Random();
    int index = 0;
    bool movingValueRight = true;

    void Start()
    {
      
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (scrollbars[index].value <= 0)
        {
            movingValueRight = true;
        }
        else if (scrollbars[index].value >= 1)
        {
            movingValueRight = false;
        }
        Move();
        LookAround();
        JumpScale();
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        _characterController.Move(move * _moveSpeed * Time.deltaTime);

        if (_characterController.isGrounded)
        {
            _velocity.y = -2f;
        }
        else
        {
            _velocity.y -= _gravity * Time.deltaTime;
        }

        _characterController.Move(_velocity * Time.deltaTime);
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        _verticalLookRotation -= mouseY;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(_verticalLookRotation, 0f, 0f);
    }

    private void JumpScale()
    {

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            index = rand.Next(0, scrollbars.Count);
            
        }
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded )
        {
            
            scrollbars[index].gameObject.active = true;
            
            if (movingValueRight)
            {
                nextActionTime = nextActionTime + Time.deltaTime;
                scrollbars[index].value = nextActionTime;
            }
            else
            {
                nextActionTime = nextActionTime - Time.deltaTime;
                scrollbars[index].value = nextActionTime;
            }

        }

        if(Input.GetKeyUp(KeyCode.Space) && _characterController.isGrounded)
        {
            
            scrollbars[index].gameObject.active = false;
            _jumpForce = jumpForceRange[index].GetScrollValue();
            Debug.Log(_jumpForce);
            _velocity.y = Mathf.Sqrt(_jumpForce  * _gravity);
            nextActionTime = 0f;
        }
    }
}

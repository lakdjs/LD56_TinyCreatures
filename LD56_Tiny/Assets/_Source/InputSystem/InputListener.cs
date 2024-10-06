using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private float _verticalLookRotation;
    [SerializeField] private float _mouseSensitivity = 200f;

    private CharacterController _characterController;
    private Transform _cameraTransform;

    private Player _player;
    private PlayerMovement _playerMovement;

    private Vector3 _moveDir = new Vector3();

    public void Construct(Player player, PlayerMovement playerMovement, CharacterController carachterController, Transform cameraTransform)
    {
        _player = player;
        _playerMovement = playerMovement;
        _characterController = carachterController; 
        _cameraTransform = cameraTransform; 
    }

    private void Update()
    {
        ReadJump();
        ReadMove();
        LookAround();
    }

    private void ReadMove()
    {
        float moveX = Input.GetAxis(Horizontal);
        float moveZ = Input.GetAxis(Vertical);

        Vector3 move = _player.transform.right * moveX + _player.transform.forward * moveZ;

        _characterController.Move(move * _player.PlayerSpeed * Time.deltaTime);

        if (_characterController.isGrounded)
        {
            _moveDir.y = -2f;
        }
        else
        {
            _moveDir.y -= _player.Gravity * Time.deltaTime;
        }

        _characterController.Move(_moveDir * Time.deltaTime);
    }

    private void ReadJump()
    {
        if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            _moveDir.y = Mathf.Sqrt(_player.PlayerJumpForce * 2f * _player.Gravity);
        }
    }
    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _player.transform.Rotate(Vector3.up * mouseX);

        _verticalLookRotation -= mouseY;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _cameraTransform.localRotation = Quaternion.Euler(_verticalLookRotation, 0f, 0f);
    }
}

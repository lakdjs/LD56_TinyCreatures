using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 3f;
    [SerializeField] private float _gravity = 9.8f;
    [SerializeField] private float _mouseSensitivity = 200f;

    private CharacterController _characterController;
    private Vector3 _velocity;
    private float _verticalLookRotation;

    private Transform _cameraTransform;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = Camera.main.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
        LookAround();
        Jump();
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

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && _characterController.isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpForce * 2f * _gravity);
        }
    }
}

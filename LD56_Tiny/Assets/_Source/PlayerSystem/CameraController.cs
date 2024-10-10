using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    [SerializeField] float sensitivity = 3; // чувствительность мышки
    [SerializeField] float limit = 80; // ограничение вращения по Y
    [SerializeField] float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
    [SerializeField] float zoomMax = 10; // макс. увеличение
    [SerializeField] float zoomMin = 3; // мин. увеличение
    [SerializeField] float X, Y;

    void Start()
    {
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom;
        offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

        if (Input.GetKey(KeyCode.Mouse1))
        {
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
            Y += Input.GetAxis("Mouse Y") * sensitivity;
            Y = Mathf.Clamp(Y, -limit, 0);
            //transform.localEulerAngles = new Vector3(-Y, X, 0);
            transform.position = transform.localRotation * offset + target.position;
        }

    }
}

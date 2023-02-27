using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField]
    private Transform _playerBody;
    [SerializeField]
    private float _mouseSensitivity = 100;

    private float _xRotation = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90); //Ограничение вращения камеры от -90 до 90

        transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);

        _playerBody.Rotate(Vector3.up * mouseX);
    }
}

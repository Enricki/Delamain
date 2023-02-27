using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Transform _groundCheck;
    [SerializeField]
    private LayerMask _groundMask;

    [SerializeField]
    private float _speed = 10f;
    [SerializeField]
    private float _gravity = -9.8f;
    [SerializeField]
    private float _jumpHeight = 3f;
    [SerializeField]
    private float _groundDistance = 0.4f;
    [SerializeField]
    [Range(0f, 2f)]
    private float _sprintMultiplier = 1f;

    private Vector3 _velocity;
    private float _actualSpeed;

    bool isGrounded;

    private void Update()
    {
        GroundCheck();
        RunCheck();
        Move();
        Jump();
        Crouch();
    }

    private void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);
        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y += _gravity * Time.deltaTime;
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * _actualSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * _gravity);
        }
        _controller.Move(_velocity * Time.deltaTime);
    }


    //Баг с застреванием, и модель вместе с коллайдером уходит в пол, нужно сд
    //сделать проверку на то, есть ли объект сверху
    private void Crouch()
    {
        if (Input.GetKey(KeyCode.C))
        {
            _controller.height = 1f;
        }
        else _controller.height = 2;
    }

    private void RunCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _actualSpeed = _speed + (_speed * _sprintMultiplier);
        }
        else _actualSpeed = _speed;
    }
}
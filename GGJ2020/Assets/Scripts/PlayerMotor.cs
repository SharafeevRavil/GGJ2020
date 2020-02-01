﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public float runSpeed = 5f;
    public float walkSpeed = 1.5f;

    public float gravity = -9.81f;
    public float groundDistance = 0.2f;
    public float jumpHeight = 2f;

    public LayerMask ground;
    public Vector3 drag = new Vector3(8, 0, 8);

    public Transform cameraTransform;
    private CharacterController _controller;
    private Animator _animator;

    private Vector3 _velocity;
    private bool _isGrounded;
    public Transform groundChecker;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //check is grounded
        _isGrounded =
            Physics.CheckSphere(groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;
        //horizontal move
        float speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);

        Vector3 move = RotateWithView(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        move *= Time.deltaTime * speed;
        _controller.Move(move);

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        _animator.SetFloat("Speed", move.magnitude);
        
        //
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            _velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        //Gravity
        _velocity.y += gravity * Time.deltaTime;
        //Some magic
        _velocity.x /= 1 + drag.x * Time.deltaTime;
        _velocity.y /= 1 + drag.y * Time.deltaTime;
        _velocity.z /= 1 + drag.z * Time.deltaTime;
        //submit vertical
        _controller.Move(_velocity * Time.deltaTime);
    }

    private Vector3 RotateWithView(Vector3 move)
    {
        Vector3 dir = cameraTransform.TransformDirection(move);
        dir.Set(dir.x, 0, dir.z);
        return dir.normalized * move.magnitude;
    }
}
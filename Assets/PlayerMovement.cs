using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    InputController _input;
    public float Speed=1;

    public float JumpSpeed=10;

    private Vector3 _lastVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<InputController>();
    }

    void Update()
    {
       
        Move();

    }

    private void Jump(ref Vector3 velocity)
    {
        velocity.y = JumpSpeed;
    }

    private bool ShouldJump()
    {
        return _input.Jump; 
    }

    private void Move()
    {
        Vector3 direction = new Vector3(_input.Move.x, 0, _input.Move.y);
        //_characterController.SimpleMove(direction * Speed);
        Vector3 velocity = new Vector3();
        velocity.x = direction.x * Speed ;
        velocity.y = _lastVelocity.y;
        velocity.z = direction.z * Speed;        

        velocity.y = GetGravity();
        if (ShouldJump())
            Jump(ref velocity);

        _characterController.Move(velocity * Time.deltaTime);

        //Turn
        if (direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;
            transform.LookAt(target);
        }
        _lastVelocity = velocity;
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }
}

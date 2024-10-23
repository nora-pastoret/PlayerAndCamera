using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    InputController _input;
    GroundChecker _groundChecker;

    public float Speed=1;

    public float JumpSpeed=10;
    public float AirControl=0.1f;

    public float TurnSpeed = 1;

    private Vector3 _lastVelocity;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _input = GetComponent<InputController>();
        _groundChecker = GetComponentInChildren<GroundChecker>();
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
        return _input.Jump && _groundChecker.Grounded; 
    }

    private void Move()
    {
        var localInput = transform.right * _input.Move.x + transform.forward * _input.Move.y;
        Vector3 direction = new Vector3(localInput.x, 0, localInput.z);
        //_characterController.SimpleMove(direction * Speed);
        Vector3 velocity = new Vector3();

        float smoothFactor = _groundChecker.Grounded? 1 : AirControl * Time.deltaTime;

        velocity.x = Mathf.Lerp(_lastVelocity.x,direction.x * Speed, smoothFactor) ;
        velocity.y = _lastVelocity.y;
        velocity.z = Mathf.Lerp(_lastVelocity.z,direction.z * Speed, smoothFactor);        

        velocity.y = GetGravity();
        if (ShouldJump())
            Jump(ref velocity);

        
            _characterController.Move(velocity * Time.deltaTime);

        //Turn
        if (direction.magnitude > 0)
        {
            Vector3 target = transform.position + direction;
            Vector3 current = transform.position + transform.forward;
            Vector3 look = Vector3.Lerp(current, target, TurnSpeed * Time.deltaTime);
            transform.LookAt(look);
        }
        _lastVelocity = velocity;
    }

    private float GetGravity()
    {
        return _lastVelocity.y + Physics.gravity.y * Time.deltaTime;
    }
}

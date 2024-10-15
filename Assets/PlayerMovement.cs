using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController _characterController;
    public float Speed=1;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _characterController.SimpleMove(Vector3.right * Speed);
    }
}

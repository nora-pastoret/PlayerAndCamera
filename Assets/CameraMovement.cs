using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
   
    //CamaraController _camaracontroller; //preguntar charachter controler si ho podem aplicar camara
    InputController _input;

    public float Speed = 1;

    void Start()
    {
        
        _input = GetComponent<InputController>();
    }

    void Update()
    {
        Look();
    }

    private void Look()
    {
        var localInput =  _input.Look.x ; //aixo funcionara amb el ratoli??
      //buscar rotate amb y vector3 amb la y
        //transform.Rotate();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookingforcamera : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    private float _cameraRotate;
    private float _bodyRotate;

    private readonly string vertical = "Mouse Y";
    private readonly string horizontal = "Mouse X";
    
    private void Update()
    {


        _camera.Rotate(Vector3.right * _speed * -Input.GetAxis(vertical)*Time.deltaTime);
        _body.Rotate(Vector3.up * _speed * Input.GetAxis(horizontal) * Time.deltaTime);
        
    }
}

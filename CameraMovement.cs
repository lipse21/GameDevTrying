using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Necessary component")]
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _body;

    [Header("Characteristics")]
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _minXAngle = -70f;
    [SerializeField] private float _maxXAngle = 50f;

    private float x_axis;
    private float y_axis;
    private Vector3 _currentPosition;
   
    private float _currentXAngle = 0f;

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        x_axis = Input.GetAxis(constants.MouseHorizontal);
        y_axis = Input.GetAxis(constants.MouseVertical);

        _body.Rotate(Vector3.up * _speedRotation * x_axis * Time.deltaTime);

        _currentXAngle -= _speedRotation * y_axis * Time.deltaTime;
        _currentXAngle = Mathf.Clamp(_currentXAngle, _minXAngle, _maxXAngle);

        _camera.localEulerAngles = new Vector3(_currentXAngle, _camera.localEulerAngles.y, 0);
    }
}
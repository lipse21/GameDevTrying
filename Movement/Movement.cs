using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _maxRayDistance;

    private Rigidbody _rigidbody;
    private readonly string _horizontal = "Horizontal";
    private readonly string _vertical = "Vertical";

    public event Action<float, float> IsMoving;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsGrounded(out RaycastHit hit))
        {
            Move();
            if (Input.GetButtonDown("Jump"))
                Jump();
        }
    }

    private bool IsGrounded(out RaycastHit hit)
    {
        return Physics.Raycast(transform.position, Vector3.down,out hit, _maxRayDistance);
    }

    private void Move()
    {
        float h_axis = Input.GetAxis(_horizontal);
        float v_axis = Input.GetAxis(_vertical);
        IsMoving?.Invoke(h_axis, v_axis);
        if (IsGrounded(out RaycastHit hit))
        {
            Vector3 MoveDirection = ((transform.right * h_axis) + (transform.forward * v_axis)) * _speed * Time.deltaTime;
            Vector3 ProjectedMove = Vector3.ProjectOnPlane(MoveDirection, hit.normal);
            _rigidbody.velocity = new Vector3(ProjectedMove.x, _rigidbody.velocity.y, ProjectedMove.z);
        }
    }

    private void Jump()
    {            
            Vector3 jumpVelocity = new Vector3(_rigidbody.velocity.x, _jumpForce, _rigidbody.velocity.z);
            _rigidbody.velocity = jumpVelocity; 
    }
}


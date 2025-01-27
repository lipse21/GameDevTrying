using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    [SerializeField] private Movement _player;

    private Animator _animator;
    private int _horizontalHash = Animator.StringToHash("h-axis");
    private int _verticalHash = Animator.StringToHash("v-axis");

    private void Start()
    {
        _animator = GetComponent<Animator>();        
    }

    private void OnEnable()
    {
        _player.IsMoving += SetMovementAnimation;
    }

    private void OnDisable()
    {
        _player.IsMoving -= SetMovementAnimation;
    }

    private void SetMovementAnimation(float h_axis,float v_axis)
    {
        _animator.SetFloat(_horizontalHash, h_axis);
        _animator.SetFloat(_verticalHash, v_axis);
    }
}

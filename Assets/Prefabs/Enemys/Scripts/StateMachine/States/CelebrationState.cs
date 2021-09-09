using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class CelebrationState : State
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _animator.Play("Celabration");
    }
    private void OnDisable()
    {
        _animator.StopPlayback();
    }
}

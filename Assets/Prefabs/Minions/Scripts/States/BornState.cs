using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornState : State
{
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("Spawn");
    }
}

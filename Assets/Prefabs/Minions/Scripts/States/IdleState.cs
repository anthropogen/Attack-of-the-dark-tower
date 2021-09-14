
using UnityEngine;

public class IdleState : State
{
    private Animator _animator;
    private void OnEnable()
    {
        _animator.SetBool("Idle",true);
    }
    private void OnDisable()
    {
        _animator.SetBool("Idle", false);
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}

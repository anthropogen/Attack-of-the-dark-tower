using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : AttackState
{
    private Animator _animator;
    protected override void Attack(Character target)
    {
        _animator.SetTrigger("Attack");
        target.TakeDamage(damage);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
   
}


using UnityEngine;

public class MeleeAttackState : AttackState
{
    private Animator _animator;
    protected override void Attack(Character target)
    {
        if (target!=null)
        {
        _animator.SetTrigger("Attack");
        target.TakeDamage(damage);
        }
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
   
}

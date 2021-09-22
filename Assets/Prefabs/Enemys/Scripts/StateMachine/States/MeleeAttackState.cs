
using UnityEngine;

public class MeleeAttackState : AttackState
{
    
    protected override void Attack(Character target)
    {
        if (target!=null)
        {
        _animator.SetTrigger("Attack");
        target.TakeDamage(damage);
        }
    }

    
   
}

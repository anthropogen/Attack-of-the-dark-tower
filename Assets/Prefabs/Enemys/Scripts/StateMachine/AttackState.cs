using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackState:State 
{
    [SerializeField] protected int damage;
    [SerializeField] protected float delay;
    protected float _lastAttackTime;
    protected abstract void Attack(Character target);
    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = delay;
        }
        _lastAttackTime -= Time.deltaTime;
    }
}

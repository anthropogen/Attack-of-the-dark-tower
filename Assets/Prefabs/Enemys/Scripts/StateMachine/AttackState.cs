
using UnityEngine;

public abstract class AttackState:State 
{
    [SerializeField] protected int damage;
    [SerializeField] private AnimationClip attack;
    protected Animator _animator;
    protected float _lastAttackTime;
    protected abstract void Attack(Character target);
    private float delay;
    private void Start()
    {
        delay = attack.length;
        _lastAttackTime = 0;
        _animator = GetComponent<Animator>();
        Debug.Log(delay);
    }
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

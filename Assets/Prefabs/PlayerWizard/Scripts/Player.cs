using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : Character
{
    [SerializeField] private List<Spell> spells;
    [SerializeField] private Transform castPoint;
    [SerializeField] private float dealyAfterAttack1;
    [SerializeField] private float delayBeforeAttack1;
    [SerializeField] private float dealyAfterAttack2;
    [SerializeField] private float delayBeforeAttack2;
    private bool IsAttacking;
    private Spell _currentSpell;
    private float _currentHealth;
    private Animator _animator;
    public int Money { get; private set; }
    public UnityAction<float, float> HealthChanged;
   private void Start()
    {
        _currentSpell = spells[0];
        _currentHealth = health;
        HealthChanged?.Invoke(_currentHealth, health);
        _animator = GetComponent<Animator>();
        IsAttacking = false;
        
    }

    public void AddMoney(int reward)
    {
        Money += reward;
    }
    private void Update()
    {
       if(Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject()&&_currentSpell!=null)
        {
            if (IsAttacking==false)
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                IsAttacking = true;
                if (_currentSpell.IsProjectile)
                {
                    _animator.SetTrigger("Attack2");
                    StartCoroutine(Attack(delayBeforeAttack2, dealyAfterAttack2, clickPosition));
                    return;
                }
                _animator.SetTrigger("Attack1");
                StartCoroutine(Attack(delayBeforeAttack1,dealyAfterAttack1,clickPosition));
            }  
        }
    }
   private IEnumerator Attack(float delayBeforeAttack1,float delayAfterAttack,Vector2 target)
    {
        yield return new WaitForSeconds(delayBeforeAttack1);
        _currentSpell.Shoot(target, castPoint.position);
        yield return new WaitForSeconds(delayAfterAttack);
        IsAttacking = false;
    }

    public override void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, health);
        if (_currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }
}

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
    [SerializeField] private float maxMana;
    [SerializeField] private float speedRegenMana;
    private float _currentMana;
    private bool IsAttacking;
    private Spell _currentSpell;
    private float _currentHealth;
    private Animator _animator;
    public int Money { get; private set; }
    public UnityAction<float, float> HealthChanged;
    public UnityAction<float, float> ManaChanged;
   private void Start()
    {
        _currentSpell = spells[0];
        _currentHealth = health;
        _currentMana = maxMana;
        HealthChanged?.Invoke(_currentHealth, health);
        ManaChanged?.Invoke(_currentMana, maxMana);
        _animator = GetComponent<Animator>();
        IsAttacking = false;
        StartCoroutine(RegenerationMana());
        
    }
    public void AddMoney(int reward)
    {
        Money += reward;
    }
    
    private void Update()
    {
       if(Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject()&&_currentSpell!=null)
        {
            if (IsAttacking==false&&_currentMana>_currentSpell.CostMana)
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                IsAttacking = true;
                if (_currentSpell.IsProjectile)
                {
                    _animator.SetTrigger("Attack2");
                    StartCoroutine(Attack(delayBeforeAttack2, dealyAfterAttack2, clickPosition));
                }
                else
                {
                    _animator.SetTrigger("Attack1");
                    StartCoroutine(Attack(delayBeforeAttack1, dealyAfterAttack1, clickPosition));
                }
                _currentMana -= _currentSpell.CostMana;
                ManaChanged?.Invoke(_currentMana, maxMana);
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
    private IEnumerator RegenerationMana()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedRegenMana);
            _currentMana++;
            if (_currentMana>maxMana)
            {
                _currentMana = maxMana;
            }
            ManaChanged?.Invoke(_currentMana, maxMana);
        }
    }
}

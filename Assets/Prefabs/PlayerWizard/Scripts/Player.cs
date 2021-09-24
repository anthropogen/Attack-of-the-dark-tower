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
    [SerializeField] private SpellsPool spellsPool;
    [SerializeField] private int level;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip soundAttack1;
    [SerializeField] private AudioClip soundAttack2;
    [SerializeField] private Spawner spawner;
    private float _currentMana;
    private bool _IsAttacking;
    private int _currentSpellIndex=0;
    private Spell _currentSpell;
    private float _currentHealth;
    private Animator _animator;
    public int Level => level;
    public float MaxMana => maxMana;
    public float SpeedRegenMana => speedRegenMana;
    public int Crystal { get; private set; }
    public event UnityAction<float, float> HealthChanged;
    public event UnityAction<float, float> ManaChanged;
    public event UnityAction CrystalChanged;
    public event UnityAction PlayerDead;
    public event UnityAction LevelUped;
   private void Start()
    {
        ChangeSpell(spells[_currentSpellIndex]);
        ResetCharacter();
        HealthChanged?.Invoke(_currentHealth, maxHealth);
        ManaChanged?.Invoke(_currentMana, maxMana);
        CrystalChanged?.Invoke();
        _animator = GetComponent<Animator>();   
        StartCoroutine(RegenerationMana()); 
    }
    private void OnEnable()
    {
        spawner.AllEnemyDied += UpLevel;
    }
    private void OnDisable()
    {
        spawner.AllEnemyDied -= UpLevel;
    }
    public override void ResetCharacter()
    {
        _currentHealth = maxHealth;
        _currentMana = maxMana;
        _IsAttacking = false;
        IsDeath = false;
    }
    
    private void Update()
    {
       if(Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject()&&_currentSpell!=null)
        {
            if (_IsAttacking==false&&_currentMana>_currentSpell.CostMana)
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _IsAttacking = true;
                if (_currentSpell.IsProjectile)
                {
                    _animator?.SetTrigger("Attack2");
                    source?.PlayOneShot(soundAttack2);
                    StartCoroutine(Attack(delayBeforeAttack2, dealyAfterAttack2, clickPosition));
                }
                else
                {
                    source?.PlayOneShot(soundAttack1);
                    _animator?.SetTrigger("Attack1");
                    StartCoroutine(Attack(delayBeforeAttack1, dealyAfterAttack1, clickPosition));
                }
                _currentMana -= _currentSpell.CostMana;
                ManaChanged?.Invoke(_currentMana, maxMana);
            }  
        }
    }
  
    private void UpLevel()
    {
        level++;
        maxMana += 0.2f;
        if (speedRegenMana>0.5)
        {
            speedRegenMana -= 0.02f;
        }
        LevelUped?.Invoke();
        Debug.Log("LevelUp");
    }
    public void AddSpell(Spell spell)
    {
        spells?.Add(spell); 
    }
   public void BuySpell(Spell newSpell )
    {
        Crystal -= newSpell.Price;
        CrystalChanged?.Invoke();
        AddSpell(newSpell);
    }
    public void AddMana(int addedMana)
    {
        _currentMana += addedMana;
        if (_currentMana>maxMana)
        {
            _currentMana = maxMana;
        }
        ManaChanged?.Invoke(_currentMana, maxMana);
        Debug.Log("added mana");
    }
    public void AddMoney(int reward)
    {
        Crystal += reward;
        CrystalChanged?.Invoke();
    }
    public void AddHealth(int health)
    {
        _currentHealth += health;
        if (_currentHealth>maxHealth)
        {
            _currentHealth = maxHealth;
        }
        HealthChanged?.Invoke(_currentHealth, maxHealth);
        Debug.Log("Added Health");
    }
   private IEnumerator Attack(float delayBeforeAttack1,float delayAfterAttack,Vector2 target)
    {
        yield return new WaitForSeconds(delayBeforeAttack1);
        _currentSpell?.Shoot(target, castPoint.position,spellsPool);
        yield return new WaitForSeconds(delayAfterAttack);
        _IsAttacking = false;
    }

    public override void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, maxHealth);
        if (_currentHealth < 0)
        {
            IsDeath = true;
            PlayerDead?.Invoke();
            gameObject.SetActive(false);
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
    public void NextSpell()
    {

        if (_currentSpellIndex==spells.Count-1)
        {
            _currentSpellIndex = 0;
        }
        else
        {
            _currentSpellIndex++;
        }
        ChangeSpell(spells[_currentSpellIndex]);
    }
    public void PreviousSpell()
    {
        if (_currentSpellIndex==0)
        {
            _currentSpellIndex = spells.Count - 1;
        }
        else
        {
            _currentSpellIndex--;
        }
        ChangeSpell(spells[_currentSpellIndex]);
    }    
    public void ChangeSpell(Spell newCurrentSpell)
    {
        _currentSpell = newCurrentSpell;
    }

   
    public void Load(int level,int crystal,float maxMana,float speedRegenMana)
    {
        this.maxMana = maxMana;
        this.level = level;
        this.Crystal = crystal;
        this.speedRegenMana = speedRegenMana;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : Character
{
    [SerializeField] private float maxMana;
    [SerializeField] private float speedRegenMana;
    [SerializeField] private int level;
    [SerializeField] private Spawner spawner;
    [SerializeField] private Attacker attacker;
    [SerializeField] private int maxMinionCount;
    private int _minionCurrentCount;
    private float _currentMana;
    private float _currentHealth;
    public Attacker Attacker => attacker;
    public int Level => level;
    public float MaxMana => maxMana;
    public float CurrentMana => _currentMana;
    public float SpeedRegenMana => speedRegenMana;
    public int Crystal { get; private set; }
    public event UnityAction<float, float> HealthChanged;
    public event UnityAction<float, float> ManaChanged;
    public event UnityAction CrystalChanged;
    public event UnityAction PlayerDead;
    public event UnityAction LevelUped;
   private void Start()
    {

        ResetCharacter();
        HealthChanged?.Invoke(_currentHealth, maxHealth);
        ManaChanged?.Invoke(_currentMana, maxMana);
        CrystalChanged?.Invoke();   
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
        IsDeath = false;
        _minionCurrentCount = 0;
    }  
    private void UpLevel()
    {
        level++;
        maxMana += 0.15f;
        if (speedRegenMana>0.5)
        {
            speedRegenMana -= 0.01f;
        }
        LevelUped?.Invoke();
        Debug.Log("LevelUp");
    }
 public void GetMana(float mana)
    {
        if (mana>_currentMana)
        {
            return;
        }
        _currentMana -= mana;
        ManaChanged?.Invoke(_currentMana, maxMana);
    }
    public void AddMana(float addedMana)
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
    public void BuySpell(Spell newSpell)
    {
        Crystal -= newSpell.Price;
        CrystalChanged?.Invoke();
        Attacker.AddSpell(newSpell);
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

    public void Load(PlayerSaveData saveData)
    {
        Debug.Log(saveData.Crystal);
        this.maxMana = saveData.MaxMana;
        this.level =saveData.Level;
        this.Crystal = saveData.Crystal;
        this.speedRegenMana =saveData.SpeedRegenMana;
    }
    public bool CanCallMinion()
    {
        if (_minionCurrentCount<maxMinionCount)
        {
            return true;
        }
        return false;
    }
    public void AddMinion()
    {
        _minionCurrentCount++;
    }
    public void OnMinionDead(Minion minion)
    {
        _minionCurrentCount--;
        minion.MinionDead -= OnMinionDead;
    }
}

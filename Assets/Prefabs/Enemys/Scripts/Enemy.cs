
using UnityEngine;
using UnityEngine.Events;
public class Enemy : Character
{
    [SerializeField] private int reward;
    private float _currentHealth;
    public event UnityAction<Enemy> Death;
    public event UnityAction<float, float> HealthChanged;
    public int Reward => reward;

    private void Start()
    {
        ResetCharacter();
    }
    private void OnEnable()
    {
       
    }
    public void Init(Player player)
    {
        _target = player;
    }
    public override void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth,maxHealth);
        if (_currentHealth<0)
        {
            IsDeath = true;
            Death?.Invoke(this);
            this.gameObject.SetActive(false);
        }
    }

    public void UpdateHealthBar()
    {
        HealthChanged?.Invoke(_currentHealth, maxHealth);
    }
    public override void ResetCharacter()
    {
        _currentHealth = maxHealth;
         IsDeath = false;
         HealthChanged?.Invoke(_currentHealth,maxHealth);
    }
}

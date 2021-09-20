
using UnityEngine;
using UnityEngine.Events;
public class Enemy : Character
{
    [SerializeField] private int reward;
    private float _currentHealth;
    public UnityAction<Enemy> Death;
    public int Reward => reward;

    private void Start()
    {
        ResetCharacter();
    }
    public void Init(Player player)
    {
        _target = player;
    }
    public override void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth<0)
        {
            IsDeath = true;
            Death?.Invoke(this);
            this.gameObject.SetActive(false);
        }
    }

    public override void ResetCharacter()
    {
        _currentHealth = health;
        IsDeath = false;
    }
}


using UnityEngine;
using UnityEngine.Events;

public class Minion : Character
{
    [SerializeField]  private Player _player;
    private float _currentHealth;
    public event UnityAction<Minion> MinionDead;
    private void Start()
    {
        ResetCharacter();
    }
    public void Init(Player player)
    {
       
        _player = player;
    }

    public override void ResetCharacter()
    {
        _currentHealth = maxHealth;
        IsDeath = false;
    }

    public override void TakeDamage(float damage)
    {
       _currentHealth -= damage;
        if (_currentHealth<=0)
        {
           IsDeath = true;
            MinionDead?.Invoke(this);
           gameObject.SetActive(false);
        }
    }
    
   
}


using UnityEngine;


public class Minion : Character
{
    [SerializeField]  private Player _player;
    private float _currentHealth;
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
        _currentHealth = health;
        IsDeath = false;
    }

    public override void TakeDamage(float damage)
    {
       _currentHealth -= damage;
        if (_currentHealth<=0)
        {
            IsDeath = true;
           gameObject.SetActive(false);
        }
    }
    
   
}

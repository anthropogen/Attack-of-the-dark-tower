
using UnityEngine;


public class Minion : Character
{
  [SerializeField]  private Player _player;
    public void Init(Player player)
    {
        _player = player;
    }
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health<=0)
        {
           
            Destroy(gameObject);
        }
    }

}

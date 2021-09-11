
using UnityEngine;
using UnityEngine.Events;

public class Minion : Character
{
   
    public UnityEvent DeathMinion;
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health<=0)
        {
            DeathMinion?.Invoke();
            Destroy(gameObject);
        }
    }
}

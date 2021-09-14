using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Enemy : Character
{
    [SerializeField] private int reward;
    public UnityAction<Enemy> Death;
    public int Reward => reward;
    public void Init(Player player)
    {
        _target = player;
    }
   
   
    public override void TakeDamage(float damage)
    {
        health -= damage;
        if (health<0)
        {
            Death?.Invoke(this);
            Destroy(gameObject);
        }
    }
   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private int reward;
    [SerializeField] private Player target;
    public Player Target => target;
    public UnityEvent Death;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health<0)
        {
            Death = null;
            Destroy(gameObject);
        }
    }
}

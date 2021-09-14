using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
   [SerializeField] protected float health;
   [SerializeField] protected Player _target;
    public Player Target => _target;
    public abstract  void TakeDamage(float damage);
}

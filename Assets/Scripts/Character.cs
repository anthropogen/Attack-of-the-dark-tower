using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
   [SerializeField] protected float health;
    public abstract  void TakeDamage(float damage);
}

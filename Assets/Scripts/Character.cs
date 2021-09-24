using UnityEngine.Events;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
   [SerializeField] protected float maxHealth;
   [SerializeField] protected Player _target;
    public bool IsDeath { get; protected set; }
    public Player Target => _target;
    public abstract  void TakeDamage(float damage);
    public abstract void ResetCharacter();
}

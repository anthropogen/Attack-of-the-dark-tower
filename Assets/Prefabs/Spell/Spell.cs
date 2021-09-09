using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class  Spell : MonoBehaviour
{
    [SerializeField] private string label;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool isByed=false;
    [SerializeField] private bool isProjectile;
    public bool IsProjectile => isProjectile;
    public abstract void Shoot(Vector3 target,Vector3 castPoint);
    
}


using UnityEngine;

public abstract class  Spell : MonoBehaviour
{
    [SerializeField] private string label;
    [SerializeField] private string description;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool isByed=false;
    [SerializeField] private bool isProjectile;
    [SerializeField] private float costMana;
    public float CostMana => costMana;
    public bool IsProjectile => isProjectile;
    public abstract void Shoot(Vector3 target,Vector3 castPoint);
    
}

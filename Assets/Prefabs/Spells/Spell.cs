
using UnityEngine;

public abstract class  Spell : MonoBehaviour
{
    [SerializeField] private string label;
    [SerializeField] private string damageDescription;
    [SerializeField] private int price;
    [SerializeField] private Sprite icon;
    [SerializeField] private bool isByed=false;
    [SerializeField] private bool isProjectile;
    [SerializeField] private float costMana;
    [SerializeField] private int indexInPool;
    public int IndexInPool => indexInPool;
    public string Label => label;
    public string DamageDescription => damageDescription;
    public int Price => price;
    public Sprite Icon => icon;
    public float CostMana => costMana;
    public bool IsProjectile => isProjectile;
    public bool IsByed => isByed;
    public abstract void Shoot(Vector3 target,Vector3 castPoint,SpellsPool pool,Player player=null);
    public void Buy()
    {
        isByed = true;
    }
    public void Load(bool isBought)
    {
        isByed = isBought;
    }

}

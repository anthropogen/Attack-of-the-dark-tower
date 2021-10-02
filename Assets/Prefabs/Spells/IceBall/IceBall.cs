
using UnityEngine;

public class IceBall : Spell
{
    [SerializeField] private Vector2 damageRange;
    [SerializeField] private float speed;
    public override void Shoot(Vector3 target,Vector3 castPoint,SpellsPool pool,Player player)
    {
        Vector2 direction = (target - castPoint).normalized;
        Vector2 dirRotate =  castPoint-target;
        float angle = Mathf.Atan2(dirRotate.y, dirRotate.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        var projectile = pool.GetFreeObject(IndexInPool).GetComponent<Projectile>(); 
        projectile.transform.position = castPoint;
        projectile.transform.rotation = rotation;
        float damage = Random.Range(damageRange.x, damageRange.y);
        projectile.InitProjectile(speed, damage, direction);
        projectile.gameObject.SetActive(true);  
    }
    
}

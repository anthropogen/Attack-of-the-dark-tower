using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : Spell
{
    [SerializeField] private Vector2 damageRange;
    [SerializeField] private float speed;
    [SerializeField] private Projectile templateIceBall;
    private Player _player;
   
  
    public override void Shoot(Vector3 target,Vector3 castPoint)
    {
      
        Vector2 direction = (target - castPoint).normalized;
        Vector2 dirRotate =  castPoint-target;
        float angle = Mathf.Atan2(dirRotate.y, dirRotate.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        var projectile =  Instantiate(templateIceBall,castPoint,rotation);
        float damage = Random.Range(damageRange.x, damageRange.y);
        projectile.InitProjectile(speed, damage, direction);
        
    }
    
}

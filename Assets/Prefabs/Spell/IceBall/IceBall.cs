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
        float damage = Random.Range(damageRange.x, damageRange.y);
        var projectile =  Instantiate(templateIceBall,castPoint,Quaternion.identity);
        projectile.InitProjectile(speed, damage, direction);
    }
}

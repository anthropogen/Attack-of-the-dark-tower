using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : Spell
{
    [SerializeField] private Explosion explosionTemplate;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float damage;
   
    public override void Shoot(Vector3 target, Vector3 castPoint)
    {
        Vector2 pos = new Vector2(target.x, target.y);
       var explosion= Instantiate(explosionTemplate, pos, Quaternion.identity);
       explosion.InitExplode(explosionRadius,damage);
    }
}

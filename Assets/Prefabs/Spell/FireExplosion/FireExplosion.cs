using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExplosion : Spell
{
    [SerializeField] private Explosion explosionTemplate;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float damage;
   
    public override void Shoot(Vector3 target, Vector3 castPoint,SpellsPool pool)
    {
        Vector2 pos = new Vector2(target.x, target.y);
        // var explosion= Instantiate(explosionTemplate, pos, Quaternion.identity);
        var explosion = pool.GetFreeObject(IndexInPool).GetComponent<Explosion>();
        explosion.transform.position = pos;
        explosion.transform.rotation = Quaternion.identity;
        explosion.gameObject.SetActive(true);
       explosion.InitExplode(explosionRadius,damage);
    }
}

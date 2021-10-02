
using UnityEngine;

public class FireExplosion : Spell
{
    [SerializeField] private float explosionRadius;
    [SerializeField] private float damage;
   
    public override void Shoot(Vector3 target, Vector3 castPoint,SpellsPool pool,Player player)
    {
        Vector2 pos = new Vector2(target.x, target.y);
        var explosion = pool.GetFreeObject(IndexInPool).GetComponent<Explosion>();
        explosion.transform.position = pos;
        explosion.transform.rotation = Quaternion.identity;
        explosion.gameObject.SetActive(true);
        explosion.InitExplode(explosionRadius,damage);
    }
}

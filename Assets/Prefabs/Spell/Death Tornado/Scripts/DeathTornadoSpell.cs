
using UnityEngine;

public class DeathTornadoSpell : Spell
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float spawnPointY;
    [SerializeField]private float timeBetweenDamage;
    public override void Shoot(Vector3 target, Vector3 castPoint, SpellsPool pool, Player player = null)
    {

        
        
        var tornado = pool.GetFreeObject(IndexInPool).GetComponent<Tornado>();
        tornado.transform.position =   new Vector3(castPoint.x,spawnPointY) ;
        tornado.Init(speed, damage, timeBetweenDamage, Vector3.left);
        tornado.gameObject.SetActive(true);
    }
}

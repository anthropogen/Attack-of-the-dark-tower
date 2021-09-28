
using UnityEngine;

public class DeathTornadoSpell : Spell
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float spawnPointY;
    [SerializeField]private float timeBetweenDamage;
    public override void Shoot(Vector3 target, Vector3 castPoint, SpellsPool pool, Player player = null)
    {

        Vector2 direction = (target - castPoint).normalized;
        Vector2 directionMove = new Vector2(direction.x, spawnPointY);
        var tornado = pool.GetFreeObject(IndexInPool).GetComponent<Tornado>();
        tornado.transform.position =   new Vector3(castPoint.x,spawnPointY) ;
        tornado.Init(speed, damage, timeBetweenDamage, directionMove);
        tornado.gameObject.SetActive(true);
    }
}

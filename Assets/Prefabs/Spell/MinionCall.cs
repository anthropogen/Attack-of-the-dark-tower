
using UnityEngine;

public class MinionCall : Spell
{
    [SerializeField] private Minion template;
    [SerializeField] private float spawnPointY;
    private Player _player;
    private void Start()
    {
        _player = GetComponent<Player>();
       
    }
    public override void Shoot(Vector3 target, Vector3 castPoint,SpellsPool pool)
    {
        Vector2 spawnPoint = new Vector2(target.x, spawnPointY);
        // var minion= Instantiate(template, spawnPoint,Quaternion.identity);
        var minion = pool.GetFreeObject(IndexInPool).GetComponent<Minion>();
        minion.ResetCharacter();
        minion.transform.position = spawnPoint;
        minion.transform.rotation = Quaternion.identity;
        minion.gameObject.SetActive(true);
        minion.GetComponent<EnemyStateMachine>().Reset();
        minion.Init(_player);
    }
}

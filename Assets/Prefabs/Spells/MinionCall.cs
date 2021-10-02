
using UnityEngine;

public class MinionCall : Spell
{
    [SerializeField] private float spawnPointY;
    private Player _player;

    public override void Shoot(Vector3 target, Vector3 castPoint,SpellsPool pool,Player player)
    {
        _player = player;
        
        if (_player.CanCallMinion())
        {
            Debug.Log("create minion");
            Vector2 spawnPoint = new Vector2(target.x, spawnPointY);
            var minion = pool.GetFreeObject(IndexInPool).GetComponent<Minion>();
            Debug.Log("Get minion");
            minion.ResetCharacter();
            minion.transform.position = spawnPoint;
            minion.transform.rotation = Quaternion.identity;
            minion.gameObject.SetActive(true);
            minion.GetComponent<EnemyStateMachine>().Reset();
            minion.Init(_player);
            _player.AddMinion();
            minion.MinionDead += _player.OnMinionDead;
        }
        else
        {
            _player.AddMana(CostMana);
        }
    }

   
}

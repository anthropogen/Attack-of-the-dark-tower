using System.Collections;
using System.Collections.Generic;
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
    public override void Shoot(Vector3 target, Vector3 castPoint)
    {
        Vector2 spawnPoint = new Vector2(target.x, spawnPointY);
       var minion= Instantiate(template, spawnPoint,Quaternion.identity);
        minion.Init(_player);
    }
}

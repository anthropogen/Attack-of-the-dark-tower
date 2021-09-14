using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> waves;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Player player;
    private Wave _currentWave;
    private int _currentWaveNumber=0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    public UnityAction AllEnemySpawned;
    public UnityAction<float,float> EnemyCountChanged;
    private void Start()
    {
        SetWave(_currentWaveNumber);
    }
    private void Update()
    {
        if (_currentWave==null)
        {
            return;
        }
        _timeAfterLastSpawn += Time.deltaTime;
        if (_timeAfterLastSpawn>_currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }
        if (_currentWave.Count<=_spawned)
        {
            if (waves.Count>_currentWaveNumber+1)
            {
                AllEnemySpawned?.Invoke();
            }
            _currentWave = null;
            _spawned = 0;
        }
    }
    private void InstantiateEnemy()
    {
        if (player != null)
        {
            var enemy = Instantiate(_currentWave.Template, spawnPoint.position, spawnPoint.rotation, spawnPoint).GetComponent<Enemy>();
            enemy.Init(player);
            enemy.Death += OnEnemyDying;
        }
    }
    private void SetWave(int index)
    {
        _currentWave = waves[index];
        EnemyCountChanged(0, 1);
    }
    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Death -= OnEnemyDying;
        player.AddMoney(enemy.Reward);
    }
    public void NextWave()
    {
       SetWave( ++_currentWaveNumber);
        _spawned = 0;
    }
}


using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using IJunior.TypedScenes;

public class Spawner : MonoBehaviour,ISceneLoadHandler<WavesConfiguration>
{

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Player player;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private EnemiesPool enemiesPool;
    private List<Enemy> enemies;
    private Wave _currentWave;
    private int _currentWaveNumber=0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    public UnityAction AllEnemySpawned;
    public UnityAction<float,float> EnemyCountChanged;
    public UnityAction AllEnemyDied;
    private void Start()
    {

        SetWave(_currentWaveNumber);
        enemies = new List<Enemy>();
    }
    private void Update()
    {
        if (_currentWave==null)
        {
            return;
        }
        _timeAfterLastSpawn += Time.deltaTime;
        if (_timeAfterLastSpawn>_currentWave.Delay())
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
        }
        if (_currentWave.Count<=_spawned)
        {
            if (_waves.Count>_currentWaveNumber+1)
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
            var enemy = enemiesPool.GetFreeObject(_currentWave.GetTemplate());
            enemy.transform.position = spawnPoint.position;
            enemy.ResetCharacter();
            enemy.GetComponent<EnemyStateMachine>().Reset();
            enemy.Init(player);
            enemy.Death += OnEnemyDying;
            enemies.Add(enemy);
            enemy.gameObject.SetActive(true);
        }
    }
    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged(0, 1);
    }
    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Death -= OnEnemyDying;
        player.AddMoney(enemy.Reward);
        enemies.Remove(enemy);
        if (_currentWaveNumber >= _waves.Count - 1&&enemies.Count<1)
        {
            Debug.Log("All enemyes spawned");
            AllEnemyDied?.Invoke();
        }
    }
    public void NextWave()
    {
       SetWave( ++_currentWaveNumber);
        _spawned = 0;
    }

    public void InitWaves(List<Wave> waves)
    {
        _waves = waves;
    }

    public void OnSceneLoaded(WavesConfiguration argument)
    {
        _waves = argument.Waves;
    }
}


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
    [SerializeField] private ScrollsPool scrollsPool;
    [SerializeField] [Range(0,100)] private int chanceSpawnScroll;
    private Camera mainCam;
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
        _currentWaveNumber = 0;
        enemies = new List<Enemy>();
        SetWave(_currentWaveNumber);
        mainCam = Camera.main;
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
            enemy.transform.rotation = Quaternion.identity;
            enemy.ResetCharacter();
            enemy.GetComponent<EnemyStateMachine>().Reset();
            enemy.Init(player);
            enemy.Death += OnEnemyDying;
            enemies.Add(enemy);
            enemy.gameObject.SetActive(true);
            enemy.UpdateHealthBar();
        }
    }
    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }
    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Death -= OnEnemyDying;
        TryGetScroll(enemy.transform.position);
        player.AddMoney(enemy.Reward);
        enemies.Remove(enemy);
        if (_currentWaveNumber >= _waves.Count - 1&&enemies.Count<1)
        {
            AllEnemyDied?.Invoke();
        }
    }
    private void  TryGetScroll(Vector2 spawnPos)
    {
        bool spawn = Random.Range(0, 100) < chanceSpawnScroll;
        if (spawn)
        {

             var scroll = scrollsPool.GetRandomObject();
              Vector3 pos = mainCam.WorldToScreenPoint(new Vector3(spawnPos.x,spawnPos.y,0));
              scroll.transform.position = pos;
              scroll.Init(player);
              scroll.gameObject.SetActive(true);
            
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
        SetWave(_currentWaveNumber);
    }
}

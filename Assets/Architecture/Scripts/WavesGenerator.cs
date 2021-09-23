using System.Collections.Generic;
using UnityEngine;

public class WavesGenerator : MonoBehaviour
{
    [SerializeField] private WavesConfiguration configuration;
    [SerializeField] private DataLoader loader;

    public WavesConfiguration GetNewWavesConfig()
    {
        int level = loader.LoadPlayerData();
        var waves = new List<Wave>();
        for (int i = 0; i < GetCount(level); i++)
        {
            waves.Add(CreateWave(level));
        }
        configuration.SetWaves(waves);
       return configuration;
    }

    private int GetCount(int level)
    {
        int count = 3;
        if (level > 3)
        {
            count = Random.Range(3, 5);
        }
        if (level > 8)
        {
            count = Random.Range(5, 7);
        }
        if (level > 15)
        {
            count = Random.Range(6, 10);
        }
        return count;
    }
    private Wave CreateWave(int level)
    {
        int enemiesCount = Random.Range(3,9);
        float minDelay = 1;
        float maxDelay = 2;
        var indexes = new List<int>();
        indexes.Add(0);
        if (level > 3)
        {
            minDelay = 0.8f;
            maxDelay = 2;
            enemiesCount = Random.Range(5, 15);
            indexes.Add(1);
        }
        if (level > 8)
        {
            minDelay = 0.7f;
            maxDelay = 1.5f;
            enemiesCount = Random.Range(10, 20);
            indexes.Add(2);
        }
         if(level > 15)
        {
            minDelay = 0.5f;
            maxDelay = 1f;
            enemiesCount = Random.Range(20, 30);
            indexes.Add(3);
        }

        var newWave = new Wave(indexes,enemiesCount,maxDelay,minDelay);
        return newWave;
    }
}

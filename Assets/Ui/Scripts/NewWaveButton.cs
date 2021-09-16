using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner spawner;
    [SerializeField] private Button nextWave;

    private void OnEnable()
    {
        spawner.AllEnemySpawned += OnAllEnemySpawned;
        nextWave.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        spawner.AllEnemySpawned -= OnAllEnemySpawned;
        nextWave.onClick.RemoveListener(OnButtonClick);
    }

    public void OnAllEnemySpawned()
    {
        nextWave.gameObject.SetActive(true);
    }    

    public void OnButtonClick()
    {
        spawner.NextWave();
        nextWave.gameObject.SetActive(false);
    }
}

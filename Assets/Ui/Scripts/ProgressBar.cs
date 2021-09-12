using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner spawner;
    private void OnEnable()
    {
        spawner.EnemyCountChanged += OnValueChanged;
    }
    private void OnDisable()
    {
        spawner.EnemyCountChanged += OnValueChanged;
    }
}

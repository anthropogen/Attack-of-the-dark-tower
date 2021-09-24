using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : Bar   
{
    [SerializeField] private Enemy enemy;

    private void OnEnable()
    {
        enemy.HealthChanged += OnValueChanged;
    }
    private void OnDisable()
    {
        enemy.HealthChanged -= OnValueChanged;
    }
}

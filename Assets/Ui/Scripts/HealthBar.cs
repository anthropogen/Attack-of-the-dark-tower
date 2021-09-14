using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar: Bar
{
    [SerializeField] private Player player;

    private void OnEnable()
    {
        player.HealthChanged += OnValueChanged;
    }
    private void OnDisable()
    {
        player.HealthChanged -= OnValueChanged;
    }
}

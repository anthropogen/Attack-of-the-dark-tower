using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaBar : Bar
{
    [SerializeField] private Player player;

    private void OnEnable()
    {
         player.ManaChanged+=OnValueChanged;
    }
    private void OnDisable()
    {
        player.ManaChanged -= OnValueChanged;
    }
}

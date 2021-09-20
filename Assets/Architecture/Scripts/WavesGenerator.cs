using System.Collections.Generic;
using UnityEngine;

public class WavesGenerator : MonoBehaviour
{
    [SerializeField] private WavesConfiguration configuration;
    [SerializeField] private Player player;

    public WavesConfiguration GetNewWavesConfig()
    {
       return configuration;
    }
}

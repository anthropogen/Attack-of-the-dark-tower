using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Waves Config",menuName = "Configs",order =51)]
public class WavesConfiguration : ScriptableObject
{
    [SerializeField] private List<Wave> waves;
    public List<Wave> Waves => waves;

    public void SetWaves(List<Wave> newWaves)
    {
        waves = newWaves;
    }
}

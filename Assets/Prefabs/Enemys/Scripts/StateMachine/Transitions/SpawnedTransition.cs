
using UnityEngine;
public class SpawnedTransition : Transition
{
    [SerializeField] private float timeDurationSpawn;
    private float _counter=0;
    private void Update()
    {
        _counter += Time.deltaTime;
        if (_counter>timeDurationSpawn)
        {
            NeedTransit = true;
        }
    }
}

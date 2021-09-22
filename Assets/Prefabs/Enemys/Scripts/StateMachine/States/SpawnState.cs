
using UnityEngine;

public class SpawnState : State
{
    
    [SerializeField] private Vector3 spawnPoint;
    private Animator _animator;
    private void Start()
    {
        transform.position = spawnPoint;
       _animator = GetComponent<Animator>();
        _animator.SetTrigger("Spawn");
    }
}

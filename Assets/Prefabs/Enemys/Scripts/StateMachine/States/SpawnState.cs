
using UnityEngine;

public class SpawnState : State
{
    
    [SerializeField] private Vector3 spawnPoint;
    private Animator _animator;
    private void Awake()
    {
       _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        transform.position = spawnPoint;
        _animator.SetTrigger("Spawn");
    }
}

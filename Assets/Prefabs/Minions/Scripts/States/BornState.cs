
using UnityEngine;

public class BornState : State
{
    [SerializeField] private AudioSource source;
    private Animator _animator;
    
    private void Start()
    {
        source.Play();
        _animator = GetComponent<Animator>();
        _animator.Play("Spawn");
    }
}

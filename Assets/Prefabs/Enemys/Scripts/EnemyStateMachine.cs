using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State firstState;
    private State _currentState;
    private Player _target;
    public State CurrentState => _currentState;
    private void Start()
    {
        _target = GetComponent<Enemy>().Target;
    }
    private void Reset(State startState)
    {
        _currentState = startState;
        if (CurrentState!=null)
        {

        }
    }
}

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
        Reset(firstState);
    }
    private void Reset(State startState)
    {
        _currentState = startState;
        if (CurrentState!=null)
        {
            CurrentState.Enter(_target);
        }
    }
    private void Update()
    {
        if (_currentState==null)
        {
            return;
        }
      var next = _currentState.GetNext();
        if (next!=null)
        {
            Transit(next);
        }
    }
    private void Transit(State nextState
        
        )
    {
        if (_currentState!=null)
        {
            _currentState.Exit();
        }
        _currentState = nextState;
        if (_currentState!=null)
        {
            _currentState.Enter(_target);
        }
    }
}

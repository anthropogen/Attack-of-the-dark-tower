using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State firstState;
    private State _currentState;
    private Player _targetPlayer;
    private Character _targetCharacter;
    private Character _currentTarget;
    public Player Player => _targetPlayer;
    public State CurrentState => _currentState;
    private void Start()
    {
        _currentTarget= _targetPlayer = GetComponent<Character>().Target;
        Reset(firstState);
    }
    private void Reset(State startState)
    {
        _currentState = startState;
        if (CurrentState!=null)
        {
            CurrentState.Enter(_currentTarget);
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
            _currentState.Enter(_currentTarget);
        }
    }
    public void ChangeTarget(Character newTarget)
    {
        _currentTarget = newTarget;
    }

}

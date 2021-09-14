
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State firstState;
    [SerializeField] private bool isRight;
    private State _currentState;
    private Player _targetPlayer;
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
       
            if (_currentTarget != null)
            {
                if (transform.position.x > _currentTarget.transform.position.x && !isRight || transform.position.x < _currentTarget.transform.position.x && isRight)
                {
                    Spin();
                }
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
    private void Spin()
    {
        transform.Rotate(0, 180, 0);
        isRight = !isRight;
    }
}

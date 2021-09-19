
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private float speed;
    [SerializeField] private float groundY;
    private float currentPositionX;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
       _animator.SetBool("Run",true);
    }
    private void OnDisable()
    {
      _animator.SetBool("Run", false);
    }
    private void Update()
    {
        
        if (Target!=null)
        {
            Vector2 pos = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
            pos.y = groundY;
            transform.position = pos;
        }
        else
        {
            Debug.Log("null player");
        }
    }
}

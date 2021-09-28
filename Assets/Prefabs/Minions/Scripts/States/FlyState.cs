
using UnityEngine;

public class FlyState: State
{
    [SerializeField] private float speed;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _animator.SetBool("Run", true);
    }
    private void OnDisable()
    {
        _animator.SetBool("Run", false);
    }
    private void Update()
    {

        if (Target != null)
        {
           transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, speed * Time.deltaTime);
            
        }
        else
        {
            Debug.Log("null player");
        }
    }
}

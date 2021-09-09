using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float delayAfterCollison;
    private float _speed;
    private float _damage;
    private Vector3 _direction;
    private Animator _animator;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
    }
    public void InitProjectile(float speed,float damage,Vector3 direction )
    {
        _speed = speed;
        _damage = damage;
        _direction = direction;
    }


    void Update()
    { 
        transform.position += _direction * Time.deltaTime * _speed;  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
            _speed = 0;
            _animator.Play("Break");
            StartCoroutine(Disable());
        }
    }
    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(delayAfterCollison);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed;
    private float _damage;
    private Vector2 _direction;
    public void InitProjectile(float speed,float damage,Vector2 direction )
    {
        _speed = speed;
        _damage = damage;
        _direction = direction;
    }


    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}

using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float delayAfterCollison;
    [SerializeField] private int layerValue;
    [SerializeField] private int secondLayerValue;
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
        if (collision.gameObject.layer == layerValue||collision.gameObject.layer==secondLayerValue)
        {
            if (collision.TryGetComponent(out Character character))
            {
                character.TakeDamage(_damage);
                _speed = 0;
                _animator.Play("Break");
                StartCoroutine(Disable());
            }
        }
        if (collision.gameObject.GetComponent<Destroer>())
        {
            gameObject.SetActive(false);
        }
    }
    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(delayAfterCollison);
        gameObject.SetActive(false);
    }
}

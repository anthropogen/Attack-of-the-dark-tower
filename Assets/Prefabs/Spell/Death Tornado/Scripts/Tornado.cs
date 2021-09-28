
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private int layerValue;
    [SerializeField] private int secondLayerValue;
    private float _speed;
     private float _damage;
     private float _timeBetweenDamage;
     private float _currentTime;
     private Vector3 _direction;
    
    public void Init(float speed, float damage, float timeBetweenDamage, Vector3 direction)
    {
        _speed = speed;
        _damage = damage;
        _timeBetweenDamage = timeBetweenDamage;
        _direction = direction;
        _currentTime = 0;
    }
    private void Update()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime>_timeBetweenDamage)
        {
            _currentTime = 0;
        }
        transform.position += _direction * Time.deltaTime * _speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_currentTime > _timeBetweenDamage)
        {
            if (collision.gameObject.layer == layerValue || collision.gameObject.layer == secondLayerValue)
            {
                if (collision.TryGetComponent(out Character character))
                {
                    character.TakeDamage(_damage);      
                }
            }
        }
        if (collision.GetComponent<Destroer>())
        {
            gameObject.SetActive(false);
        }
    }

}

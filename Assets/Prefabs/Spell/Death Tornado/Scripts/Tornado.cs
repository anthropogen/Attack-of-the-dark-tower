
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private int layerValue;
    [SerializeField] private float radiusDamage;
    private float _speed;
     private float _damage=1;
     private float _timeBetweenDamage=1;
     private float _currentTime=0;
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
            Damage();
            _currentTime = 0;
        }
        transform.position += _direction*_speed * Time.deltaTime ;
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Destroer>())
        {
            gameObject.SetActive(false);
        }
    }

   private void Damage()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radiusDamage, Vector2.zero);
        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {

                if (hit.collider.gameObject.layer == layerValue)
                {
                    if (hit.transform.gameObject.TryGetComponent(out Character character))
                    {
                        character.TakeDamage(_damage);
                    }
                }
            }
        }
    }
}

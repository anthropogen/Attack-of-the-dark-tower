using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Enemy : Character
{
    [SerializeField] private int reward;
    [SerializeField] private Player target;
    [SerializeField] private Color damageView;
    [SerializeField] private float timeViewDamage;
    private Color _default;
    private SpriteRenderer _renderer;
    public Player Target => target;
    public UnityEvent Death;
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _default = _renderer.color;
    }
    public override void TakeDamage(float damage)
    {
        health -= damage;
        StartCoroutine(ViewDamage());
        if (health<0)
        {
            Death = null;
            Destroy(gameObject);
        }
    }
    private IEnumerator ViewDamage()
    {
        _renderer.color = damageView;
        yield return new WaitForSeconds(timeViewDamage);
        _renderer.color = _default;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private List<Spell> spells;
    [SerializeField] private Transform castPoint;
    private Spell _currentSpell;
    private int _currentHealth;
    private Animator _animator;
    public int Money { get; private set; }
    
   private void Start()
    {
        _currentSpell = spells[0];
        //_currentHealth = health;
        _animator = GetComponent<Animator>();
        
    }

    
   private void Update()
    {
       if(Input.GetMouseButtonDown(0)&&!EventSystem.current.IsPointerOverGameObject()&&_currentSpell!=null)
        {
            _currentSpell.Shoot(Camera.main.ScreenToWorldPoint(Input.mousePosition),transform.position);  
        }
    }
    public void OnEnemyDeath(int reward)
    {
        Money += reward;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Attacker : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private List<Spell> spells;
    [SerializeField] private Transform castPoint;
    [SerializeField] private float dealyAfterAttack1;
    [SerializeField] private float delayBeforeAttack1;
    [SerializeField] private float dealyAfterAttack2;
    [SerializeField] private float delayBeforeAttack2;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip soundAttack1;
    [SerializeField] private AudioClip soundAttack2;
    [SerializeField] private SpellsPool spellsPool;
    private bool _IsAttacking;
    private int _currentSpellIndex = 0;
    private Spell _currentSpell;
    private Animator _animator;
    private void Start()
    {
        _IsAttacking = false;
        ChangeSpell(spells[_currentSpellIndex]);
        _animator = GetComponent<Animator>();
    }
    private void Update()
    { 
        if (Input.touchCount==1)
        {
            Touch touch=Input.GetTouch(0);
            if (touch.phase==TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    if (_IsAttacking == false && player.CurrentMana > _currentSpell.CostMana)
                    {
                        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        _IsAttacking = true;
                        if (_currentSpell.IsProjectile)
                        {
                            _animator?.SetTrigger("Attack2");
                            source?.PlayOneShot(soundAttack2);
                            StartCoroutine(Attack(delayBeforeAttack2, dealyAfterAttack2, clickPosition));
                        }
                        else
                        {
                            source?.PlayOneShot(soundAttack1);
                            _animator?.SetTrigger("Attack1");
                            StartCoroutine(Attack(delayBeforeAttack1, dealyAfterAttack1, clickPosition));
                        }
                        player.GetMana(_currentSpell.CostMana);
                    }
                }
            }
        }
    }
  
    private IEnumerator Attack(float delayBeforeAttack1, float delayAfterAttack, Vector2 target)
    {
        yield return new WaitForSeconds(delayBeforeAttack1);
        _currentSpell?.Shoot(target, castPoint.position, spellsPool,player);
        yield return new WaitForSeconds(delayAfterAttack);
        _IsAttacking = false;
    }
    public void AddSpell(Spell spell)
    {
        spells.Add(spell);
    }
   
    public void NextSpell()
    {

        if (_currentSpellIndex == spells.Count - 1)
        {
            _currentSpellIndex = 0;
        }
        else
        {
            _currentSpellIndex++;
        }
        ChangeSpell(spells[_currentSpellIndex]);
    }
    public void PreviousSpell()
    {
        if (_currentSpellIndex == 0)
        {
            _currentSpellIndex = spells.Count - 1;
        }
        else
        {
            _currentSpellIndex--;
        }
        ChangeSpell(spells[_currentSpellIndex]);
    }
    public void ChangeSpell(Spell newCurrentSpell)
    {
        _currentSpell = newCurrentSpell;
    }
}


using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<Spell> spells;
    [SerializeField] private Player player;
    [SerializeField] private SpellView template;
    [SerializeField] private GameObject itemContainer;
    public List<Spell> Spells => spells;
   
   /* private void Start()
    {
        for (int i = 0; i < spells.Count; i++)
        {
            AddItem(spells[i]);
        }  
    }*/
    public void Load(List<bool> boughtSpell)
    {
        for (int i = 0; i < boughtSpell.Count; i++)
        {
            spells[i].Load(boughtSpell[i]);
        }
        for (int i = 0; i < spells.Count; i++)
        {
            AddItem(spells[i]);
        }
    }
    private void AddItem(Spell spell)
    {
        var view = Instantiate(template, itemContainer.transform);
        view.SellButtonClick += OnBuyButtonClick;
        view.Renderer(spell);
        if (spell.IsByed)
        {
            view.SellButtonClick -= OnBuyButtonClick;
            player.AddSpell(spell);
        }
    }

    private void OnBuyButtonClick(Spell spell, SpellView view)
    {
        TrySellBuySpell(spell, view);
    }
    private void TrySellBuySpell(Spell spell, SpellView view)
    {
        if (spell.Price<=player.Crystal)
        {
            player.BuySpell(spell);
            spell.Buy();
            view.SellButtonClick -= OnBuyButtonClick;
        }
    }    
}

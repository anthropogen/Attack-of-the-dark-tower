
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<Spell> spells;
    [SerializeField] private Player player;
    [SerializeField] private SpellView template;
    [SerializeField] private GameObject itemContainer;
    public List<Spell> Spells => spells;
    public void Load(PlayerSaveData saveData)
    {
        if (saveData.PurchasedSpells!=null)
        {
            for (int i = 0; i <spells.Count; i++)
            {
                foreach ( var spell in saveData.PurchasedSpells)
                {
                    if (spell.Key==spells[i].Label)
                    {
                        spells[i].Load(spell.Value);
                    }
                }
            }
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
            player.Attacker.AddSpell(spell);
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

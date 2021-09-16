
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour
{
    [SerializeField] private List<Spell> spells;
    [SerializeField] private Player player;
    [SerializeField] private SpellView template;
    [SerializeField] private GameObject itemContainer;
   
    private void Start()
    {
        for (int i = 0; i < spells.Count; i++)
        {
            AddItem(spells[i]);
        }
    }
    private void AddItem(Spell spell)
    {
        var view = Instantiate(template, itemContainer.transform);
        view.Renderer(spell);
    }

    private void OnBuyButtonClick(Spell spell, SpellView view)
    {

    }
}

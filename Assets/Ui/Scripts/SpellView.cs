using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SpellView : MonoBehaviour
{
    [SerializeField] private TMP_Text price;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text label;
    [SerializeField] private TMP_Text damage;
    [SerializeField] private Button buyButton;
    [SerializeField] private TMP_Text costMana;
    private Spell _spell;
    public UnityAction<Spell,SpellView> SellButtonClick;

    private void OnEnable()
    {
        buyButton.onClick.AddListener(OnButtonClick);
        buyButton.onClick.AddListener(TryLockedSpell);
    }
    private void OnDisable()
    {
        buyButton.onClick.RemoveListener(OnButtonClick);
        buyButton.onClick.RemoveListener(TryLockedSpell);
    }
    private void TryLockedSpell()
    {
        if (_spell.IsByed)
        {
            buyButton.interactable = false;
        }
    }
    public void Renderer(Spell spell)
    {
        _spell = spell;
        price.text = spell.Price.ToString();
        icon.sprite = spell.Icon;
        label.text = spell.Label;
        damage.text = spell.DamageDescription;
        costMana.text = spell.CostMana.ToString();
        TryLockedSpell();    
    }
    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_spell, this);
    }
}

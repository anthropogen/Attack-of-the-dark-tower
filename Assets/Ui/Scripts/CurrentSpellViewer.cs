
using UnityEngine;
using UnityEngine.UI;
public class CurrentSpellViewer : MonoBehaviour
{
    [SerializeField] private Attacker attacker;
    [SerializeField] private Image image;
    private void OnEnable()
    {
        attacker.CurrentSpellChanged += OnCurrentSpellChanged;
    }
    private void OnDisable()
    {
        attacker.CurrentSpellChanged -= OnCurrentSpellChanged;
    }

    public void OnCurrentSpellChanged(Sprite sprite)
    {
        image.sprite = sprite;
    }
}

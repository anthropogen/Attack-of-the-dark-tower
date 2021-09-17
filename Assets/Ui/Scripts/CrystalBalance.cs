using TMPro;
using UnityEngine;

public class CrystalBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text crystalView;
    [SerializeField] private Player player;
    private void OnEnable()
    {
        player.CrystalChanged += OnCrystalChanged;
        OnCrystalChanged();
    }
    private void OnDisable()
    {
        player.CrystalChanged -= OnCrystalChanged;
        OnCrystalChanged();
    }
    private void OnCrystalChanged()
    {
        crystalView.text = player.Crystal.ToString();
    }

}

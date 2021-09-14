
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    [SerializeField] private float changeTIme;
    public void OnValueChanged(float value, float maxValue)
    {
        float newValue = value / maxValue;
        Slider.DOValue(newValue, changeTIme);
    }
}

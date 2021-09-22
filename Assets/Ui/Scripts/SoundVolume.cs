using UnityEngine.UI;
using UnityEngine;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float _volume;
    private void Start()
    {
       SetVolume(LoadVolume());
        slider.value = LoadVolume();
    }
    public void SetVolume(float value)
    {
        _volume = value;
        SaveVolume();
    }
    private void SaveVolume()
    {
        PlayerPrefs.SetFloat("Volume", _volume);
        PlayerPrefs.Save();
    }
    private float LoadVolume()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
           return PlayerPrefs.GetFloat("Volume");
        }
        return 1;
    }
}

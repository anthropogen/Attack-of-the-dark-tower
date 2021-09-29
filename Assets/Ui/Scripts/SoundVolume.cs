using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;
    private float _volume;
    private void Start()
    {
        slider.minValue = -70;
        slider.maxValue = 10; 
       SetVolume(LoadVolume());
        slider.value = LoadVolume();
    }
    public void SetVolume(float value)
    {
        _volume = value;
        mixer.SetFloat("VolumeMain", value);
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

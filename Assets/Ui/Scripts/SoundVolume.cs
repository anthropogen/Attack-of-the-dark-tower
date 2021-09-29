using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private AudioMixer mixer;
    private void Start()
    {
        slider.minValue = -50;
        slider.maxValue = 10; 
        slider.value = LoadVolume();
    }
    public void SetVolume(float value)
    {
        mixer.SetFloat("VolumeMain", value);
        SaveVolume(value);
    }
    private void SaveVolume(float value)
    { 
        PlayerPrefs.SetFloat("Volume", value);
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

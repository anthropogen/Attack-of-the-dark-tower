using IJunior.TypedScenes;
using UnityEngine;

public class SceneLoader: MonoBehaviour
{
    [SerializeField] private WavesGenerator generator;
     private WavesConfiguration _configuration;

    

    public void LoadLevel()
    {
        Time.timeScale = 1;
        _configuration = generator.GetNewWavesConfig();
        GameLevel.Load(_configuration);
    }
}

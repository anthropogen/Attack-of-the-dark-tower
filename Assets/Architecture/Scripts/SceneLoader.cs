using IJunior.TypedScenes;
using UnityEngine;

public class SceneLoader: MonoBehaviour
{
    [SerializeField] private WavesGenerator generator;
     private WavesConfiguration _configuration;

    public void CurrentLevel()
    {
        GameLevel.Load(_configuration);
    }

    public void NextLevel()
    {
        _configuration = generator.GetNewWavesConfig();
        GameLevel.Load(_configuration);
    }
}

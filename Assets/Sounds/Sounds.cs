
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioClip battle;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip lose;
    [SerializeField] private AudioSource source;
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    private void Start()
    {
        PlaySound(battle);
    }
    private void OnEnable()
    {
        player.PlayerDead += OnPlayerDead;
        spawner.AllEnemyDied += OnAllEnemiesDied;
    }
    private void OnDisable()
    {
        player.PlayerDead -= OnPlayerDead;
        spawner.AllEnemyDied -= OnAllEnemiesDied;
    }

    private void PlaySound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
    
    private void OnPlayerDead()
    {
        PlaySound(lose);
    }
    private void OnAllEnemiesDied()
    {
        PlaySound(win);
    }

}

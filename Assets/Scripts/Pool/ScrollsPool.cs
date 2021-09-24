
using UnityEngine;
public class ScrollsPool : Pool<Scroll>
{
  [SerializeField] private Player player;
  [SerializeField] private Spawner spawner;

    private void OnEnable()
    {
        player.PlayerDead += DestroyPool;
        spawner.AllEnemyDied += DestroyPool;
    }
    private void OnDisable()
    {
        player.PlayerDead -= DestroyPool;
        spawner.AllEnemyDied -= DestroyPool;
    }
    private void DestroyPool()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            for (int j = 0; j < objects[i].Count; j++)
            {
                Destroy(objects[i][j]);
            }
        }
    }

}

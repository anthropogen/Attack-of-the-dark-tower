using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    private string savePath;
    private void OnEnable()
    {
        if (spawner!=null)
        {
            spawner.AllEnemyDied += SavePlayerData;
        }
        
    }
    private void OnDisable()
    {
        if (spawner != null)
        {
            spawner.AllEnemyDied -= SavePlayerData;
        }
    }
    private void Awake()
    {
      Debug.Log(  savePath = Path.Combine( Application.persistentDataPath, "save"));
        LoadPlayerData();
    }
    public void SavePlayerData()
    {
        using (var writer = new BinaryWriter(File.Open(savePath, FileMode.OpenOrCreate)))
        {
            writer.Write(player.Level);
            writer.Write(player.Crystal);
        }
        Debug.Log("save");
    }
    public int LoadPlayerData()
    {
        int level=0,crystal = 0;
        if (File.Exists(savePath))
        {
            using (var reader = new BinaryReader(File.Open(savePath, FileMode.Open)))
            {
                Debug.Log(level = reader.ReadInt32());
                Debug.Log(crystal = reader.ReadInt32());
            }
        }
        if (player!=null)
        {
            player.Load(level, crystal);
        }
        Debug.Log("Load");
        return level;
    }
}

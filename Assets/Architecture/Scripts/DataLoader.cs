using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Spawner spawner;
    private string savePath;
    private int version = 1;
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
            writer.Write(version);
            writer.Write(player.Level);
            writer.Write(player.Crystal);
            writer.Write(player.MaxMana);

        }
    }
    public int LoadPlayerData()
    {
        int level=0,crystal = 0,maxMana=5,version=0;
        if (File.Exists(savePath))
        {
            using (var reader = new BinaryReader(File.Open(savePath, FileMode.Open)))
            {
                version = reader.ReadInt32();
                level = reader.ReadInt32();
                crystal = reader.ReadInt32();
                maxMana = reader.ReadInt32();
            }
        }
        if (player!=null)
        {
            player.Load(level, crystal,maxMana);
        }
        return level;
    }
}

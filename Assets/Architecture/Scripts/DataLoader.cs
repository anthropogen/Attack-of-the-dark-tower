using System.IO;
using UnityEngine;

public class DataLoader : MonoBehaviour
{
    [SerializeField] private Player player;
    private string savePath;
    private int version = 2;
    private void OnEnable()
    {
        if (player!=null)
        {
            player.LevelUped += SavePlayerData;
        }
    }
    private void OnDisable()
    {
        if (player!=null)
        {
            player.LevelUped -= SavePlayerData;
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
            writer.Write(player.SpeedRegenMana);
            writer.Write(player.Level);
            writer.Write(player.Crystal);
            writer.Write(player.MaxMana);

        }
    }
    public int LoadPlayerData()
    {
        int level = 0, crystal = 0, version=0;
       float maxMana = 5,speedRegenMana=1.2f;
        if (File.Exists(savePath))
        {
            using (var reader = new BinaryReader(File.Open(savePath, FileMode.Open)))
            {
                version = reader.ReadInt32();
                if (version>1)
                {
                    speedRegenMana = reader.ReadSingle();
                }
                level = reader.ReadInt32();
                crystal = reader.ReadInt32();
                maxMana = reader.ReadSingle();
            }
        }
        if (player!=null)
        {
            player.Load(level, crystal,maxMana,speedRegenMana);
        }
        Debug.Log($"level{level},crystal{crystal},maxMana{maxMana},regen{speedRegenMana}/s");
        return level;
    }
}

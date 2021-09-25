using System.IO;
using UnityEngine;
using System.Collections.Generic;
public class DataLoader : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SpellBook spellBook;
    private string savePath;
    private const int Version = 1;
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
            writer.Write(Version);
            writer.Write(player.Level);
            writer.Write(player.Crystal);
            writer.Write(player.MaxMana);
            writer.Write(player.SpeedRegenMana);
            writer.Write(spellBook.Spells.Count);
            for (int i = 0; i < spellBook.Spells.Count; i++)
            {
                writer.Write(spellBook.Spells[i].IsByed);
            }

        }
    }
    public int LoadPlayerData()
    {
        int level = 0, crystal = 0, version=0;
        float maxMana = 5,speedRegenMana=1.2f;
        List<bool> boughtSpells=new List<bool>();
        if (File.Exists(savePath))
        {
            using (var reader = new BinaryReader(File.Open(savePath, FileMode.Open)))
            {
                version = reader.ReadInt32(); 
                level = reader.ReadInt32();
                crystal = reader.ReadInt32();
                maxMana = reader.ReadSingle();
                speedRegenMana = reader.ReadSingle();
                int length = reader.ReadInt32();
                for (int i = 0; i < length; i++)
                {
                   boughtSpells.Add(reader.ReadBoolean());
                }
            }
        }
        if (player!=null)
        {
            player.Load(level, crystal,maxMana,speedRegenMana);
        }
        if (spellBook!=null)
        {
            spellBook.Load(boughtSpells);
        }
        Debug.Log($"level{level},crystal{crystal},maxMana{maxMana},regen{speedRegenMana}/s");
        return level;
    }
}

using System.IO;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
public class DataLoader : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SpellBook spellBook;
    private string _savePath;
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
        _savePath = Application.persistentDataPath + "/save.dat";
    }
    private void Start()
    {
        LoadPlayerData();
    }
    public void SavePlayerData()
    {
        Dictionary<string, bool> purchasedSpells=new Dictionary<string, bool>();
        for (int i = 0; i < spellBook.Spells.Count; i++)
        {
            purchasedSpells.Add(spellBook.Spells[i].Label, spellBook.Spells[i].IsByed);
        }
        PlayerSaveData saveData = new PlayerSaveData(player.Level,player.Crystal,player.MaxMana,player.SpeedRegenMana,purchasedSpells);
        using (FileStream file =File.Create(_savePath))
        {
            new BinaryFormatter().Serialize(file, saveData);
        }
    }
    public PlayerSaveData LoadPlayerData()
    {
        PlayerSaveData saveData;
        if (File.Exists(_savePath))
        {
            using (FileStream file = File.Open(_savePath, FileMode.Open))
            {
                var dataLoaded = new BinaryFormatter().Deserialize(file);
                saveData = (PlayerSaveData)dataLoaded;
            }
        }
        else
        {
            saveData = new PlayerSaveData();
        }
        if (player!=null)
        {
            player.Load(saveData);
        }
        if (spellBook!=null)
        {
            spellBook.Load(saveData);
        }
        return saveData;
    }
}

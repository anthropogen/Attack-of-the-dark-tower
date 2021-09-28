
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class PlayerSaveData 
{
    private int _level;
    private int _crystal;
    private float _maxMana;
    private float _speedRegenMana;
    private Dictionary<string, bool> _purchasedSpells;
    public int Level => _level;
    public int Crystal => _crystal;
    public float MaxMana => _maxMana;
    public float SpeedRegenMana => _speedRegenMana;
    public Dictionary<string, bool> PurchasedSpells => _purchasedSpells;

    public PlayerSaveData ()
    {
        _level = 0;
        _crystal = 0;
        _maxMana = 5;
        _speedRegenMana = 1.2f;
    }
    public PlayerSaveData(int level, int crystal,float maxMana,float speedManaRegen,Dictionary<string,bool> purchasedSpells)
    {
        if (level>-1&&crystal>-1&&maxMana>0&&speedManaRegen>0)
        {
            _level = level;
            _crystal = crystal;
            _maxMana = maxMana;
            _speedRegenMana = speedManaRegen;
        }
        else
        {
            _level = 0;
            _crystal = 0;
            _maxMana = 5;
            _speedRegenMana = 1.2f;
            Debug.Log("incorrect data");
        }
        _purchasedSpells = purchasedSpells;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : Singleton<GameControl> {
    
    protected GameControl(){} //Guarantee this will be always a singleton only - can't use the constructor!

    public float health = 100f;
    public float exp = 50f;

    #region SaveData
    public void Save(){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.exp = exp;

        bf.Serialize(file, data);
        file.Close();
    }
    #endregion

    #region LoadData
    public void Load(){
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            health = data.health;
            exp = data.exp;
        }
    }
    #endregion
}

[Serializable]
class PlayerData{
    public float health;
    public float exp;
}

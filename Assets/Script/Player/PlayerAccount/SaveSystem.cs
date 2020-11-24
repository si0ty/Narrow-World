using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using DTS;

public static class SaveSystem 
{
   
    public static void SaveResources(RTS.PlayerResourceManager resources) {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.narrow";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(resources);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("File successfully saved");
    }

    public static PlayerData LoadResources() {

        string path = Application.persistentDataPath + "/player.narrow";
        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data  = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            Debug.Log("File successfully loaded");
            return data;

           
        } else {
            Debug.Log("Savefile not found. New one will be created.");
            
            return null;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveController : MonoBehaviour
{
    public void saveGame() {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "medidle.idl");

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData();

        formatter.Serialize(stream, data);

        stream.Close();
    }

    public PlayerData loadGame() {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "medidle.idl");

        if (File.Exists(path)) {
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        } else {
            return null;
        }
    }

    public void deleteGame() {
        string[] filePaths = Directory.GetFiles(Application.persistentDataPath);
        foreach (string filePath in filePaths) {
            File.Delete(filePath);
        }
    }
}

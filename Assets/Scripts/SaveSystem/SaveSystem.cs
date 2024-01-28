using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(PlayerTracker playerTracker)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerSavedData data = new PlayerSavedData(playerTracker);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerSavedData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (PlayerHasData())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerSavedData data = formatter.Deserialize(stream) as PlayerSavedData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }

    public static bool PlayerHasData()
    {
        string path = Application.persistentDataPath + "/player.fun";
        return File.Exists(path);
    }
}

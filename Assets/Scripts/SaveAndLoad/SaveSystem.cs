using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem 
{
    //DirectoryPath
    private static string SaveDirectory = Application.persistentDataPath + "/DWM_SaveData/";

    //SaveGameMethod
    public static void SaveGame(SaveData data , int SlotNumber)
    {
        //check if the directory exists.
        if (!Directory.Exists(SaveDirectory))
        {
            Directory.CreateDirectory(SaveDirectory);
        }
            //CreateFile
            string path = SaveDirectory + "SaveSlot" + SlotNumber + ".bin";

            //BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Create);

            formatter.Serialize(stream, data);  //Serializing the data .
            stream.Close();
            File.WriteAllText(SaveDirectory + "SaveSlot" + SlotNumber + ".json", JsonUtility.ToJson(data, true));
            Debug.Log("Saved in Slot: " + SlotNumber);
    }

    public  static SaveData LoadGame(int SlotNumber)
    {
        string path = SaveDirectory + "SaveSlot" + SlotNumber + ".bin";

        //Check if the file exists in this path
        if (!File.Exists(path))
        {
            Debug.LogError("No save found: Slot " + SlotNumber);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        SaveData data = formatter.Deserialize(stream) as SaveData;
        stream.Close();

        return data;
    }

    public static bool SaveExists(int slotNumber)
    {
        return File.Exists(SaveDirectory + "SaveSlot" + slotNumber + ".bin");
    }
}

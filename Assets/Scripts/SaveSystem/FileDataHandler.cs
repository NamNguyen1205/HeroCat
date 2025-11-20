using System;
using System.IO;
using UnityEngine;

public class FileDataHandler
{
    private string fullPath;

    public FileDataHandler(string dataDirPath, string fileName)
    {
        fullPath = Path.Combine(dataDirPath, fileName);
        Debug.Log(fullPath);
    }

    public void SaveGameData(GameData gameData)
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            // string dataToSave = JsonUtility.ToJson(gameData, true);

            string dataToSave = gameData != null ? JsonUtility.ToJson(gameData, true) : "";

            using(FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using(StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToSave);
                }
            }
            
        }
        catch(Exception e)
        {
            Debug.LogError("Error on trying to save data to file: " + fullPath + "\n" + e);
        }
    }

    public GameData LoadGameData()
    {
        GameData loadData = null;

        if(File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using(FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("Error on trying to load data to file: " + fullPath + "\n" + e);
            }
        }

        return loadData;
    }

    // public void DeleteFileSave()
    // {
    //     SaveGameData(null);
    // }
}

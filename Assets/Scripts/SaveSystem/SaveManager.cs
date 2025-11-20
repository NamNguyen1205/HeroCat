using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private FileDataHandler fileDataHandler;
    private GameData gameData;
    [SerializeField] private string fileName = "HeroCat";
    private List<ISaveable> allSaveable;

    private void Awake()
    {

        instance = this;
    }

    private void Start()
    {
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        // gameData = new GameData();
        allSaveable = GetSaveables();

        LoadGame();
    }

    public void SaveGame()
    {
        foreach(var saveable in allSaveable)
            saveable.SaveData(ref gameData);

        fileDataHandler.SaveGameData(gameData);
    }

    public void LoadGame()
    {
        gameData = fileDataHandler.LoadGameData();
        if(gameData == null)
        {
            gameData = new GameData();
            return;
        }

        foreach(var saveable in allSaveable)
            saveable.LoadData(gameData);
        
    }

    [ContextMenu("Delete Save Data")]
    private void DeleteSaveData()
    {
        // fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        // fileDataHandler.DeleteFileSave();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<ISaveable> GetSaveables()
    {
        return FindObjectsByType<MonoBehaviour>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .OfType<ISaveable>().ToList();
    }
}

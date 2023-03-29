using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class SavedGameState
{
    public int Version = 1;
}

public enum SaveSlot
{
    None,
    Slot1,
    Slot2,
    Slot3 // We give the user 3 save slots to override their data in
}

public enum SaveType
{
    Manual,
    Automatic, // support for automatic time interval saving
    Mission // no-support yet ~ but the premise is that the game saves at specefic setpoints
}

public interface saveable
{
    void PrepareForSave(SavedGameState gameState);
}

public class Saving : MonoBehaviour
{
    [SerializeField] float autoTime = 60f; // auto-save every minute (this is in seconds)


    public static Saving Instance { get; private set; } = null; // initializing a singletone so that the instance of this script can be accessed anywhere
    private void Awake() // default singleton code (universal really)
    {
        if(Instance != null)
        {
            Debug.LogError($"Duplicated Singleton somewhere on the gameobject {gameObject.name}"); // $ - lets me access the gameobject that has a duplicated singleton 
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Instance = this;
    }
 

    void Update()
    {
        
    }

    string GetSaveFilePath(SaveSlot slot, SaveType type)
    {
        return Path.Combine(Application.persistentDataPath, $"Save_Slot{(int)slot}_{type.ToString()}.json"); // sets the save file at a known location everytime - that is what persistent Data Path and Path.Combine do

        // return string;
    } 

    public void RequestSave(SaveSlot slot, SaveType type)
    {
        SavedGameState savedState = new SavedGameState(); // creates a new instance of the class
        var filePath = GetSaveFilePath(slot, type);

        // var saveHandler = FindObjectOfType<saveable>();

        File.WriteAllText(filePath, JsonConvert.SerializeObject(savedState, Formatting.Indented));
    }
}

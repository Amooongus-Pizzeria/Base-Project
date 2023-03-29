using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;

public class SavedGameState
{
    public int Version = 1;

    public class SimpleSpawnerState
    {
        public class Entry
        {
            public GameObject Type;
            public System.Tuple<float, float, float> Location;
            // public Vector3 Rotation;
        }

        public string ID;
        public List<Entry> SpawnedObjects = new List<Entry>();
    }

    public SimpleSpawnerState SpawnerState = new SimpleSpawnerState();
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
    Automatic, // support for automatic time interval saving (not implemented in this build but exists on a seperate client)
    Mission // no-support yet ~ but the premise is that the game saves at specefic setpoints
}

public interface saveable
{
    void PrepareForSave(SavedGameState gameState);
}

public class Saving : MonoBehaviour
{
    [SerializeField] float autoTime = 60f; // auto-save every minute (this is in seconds)

    [SerializeField] bool DEBUG_SAVE_TEST = false;

    List<saveable> SaveHandlers = new List<saveable>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void LoadPersistentLevel()
    {
        for(int sceneIndex = 0;  sceneIndex < SceneManager.sceneCount; sceneIndex++)
        {
            if(SceneManager.GetSceneAt(sceneIndex).name == "SaveLoadPersistentLevel") {
                return;
            }
        }
        SceneManager.LoadScene("SaveLoadPersistentLevel", LoadSceneMode.Additive);
    }

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
        if (DEBUG_SAVE_TEST)
        {
            DEBUG_SAVE_TEST = false; // can save however many times with this as the boolean just defaults to false after ticking the checkbox
            RequestSave(SaveSlot.Slot1, SaveType.Manual); // save it in slot 1 for now
        }
    }

    public void RegisterHandler(saveable handler)
    {
        if(!SaveHandlers.Contains(handler)) // prevent adding this multiple times
            SaveHandlers.Add(handler);
    }

    public void DeRegisterHandler(saveable handler)
    {
        SaveHandlers.Remove(handler);
    }

    string GetSaveFilePath(SaveSlot slot, SaveType type)
    {
        return Path.Combine(Application.persistentDataPath, $"Save_Slot{(int)slot}_{type.ToString()}.json"); // sets the save file at a known location everytime - that is what persistent Data Path and Path.Combine do

        // return string;
    } 

    public void RequestSave(SaveSlot slot, SaveType type)
    {
        SavedGameState savedState = new SavedGameState(); // creates a new instance of the class

        foreach(var handler in SaveHandlers)
        {
            if(handler == null)
            {
                continue;
            }

            handler.PrepareForSave(savedState);

        } 
        var filePath = GetSaveFilePath(slot, type);

        Debug.Log(filePath); // logs file path so I can check where it is actually saved

        // var saveHandler = FindObjectOfType<saveable>();

        File.WriteAllText(filePath, JsonConvert.SerializeObject(savedState, Formatting.Indented));
    }
}

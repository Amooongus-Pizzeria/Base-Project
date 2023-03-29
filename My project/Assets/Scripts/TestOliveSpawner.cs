using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOliveSpawner : MonoBehaviour, saveable
{
    [SerializeField] string ID = "OliverSpawner-1"; // ID of spawner, may need multiple later, espcially when toppings are attached to different pizzas
    [SerializeField] int NumObjects = 5;
    public GameObject olive; // instantiate this game object
    List<System.Tuple<GameObject>> SpawnedOlives = new List<System.Tuple<GameObject>>(); // make the list a tuple
    // List<GameObject> SpawnedOlives = new List<GameObject>();

    public void PrepareForSave(SavedGameState gameState)
    {
        // throw new System.NotImplementedException(); default, generated statement i commented out
        gameState.SpawnerState.ID = ID;
        foreach (var spawned in SpawnedOlives)
        {
            var location = spawned.Item1.transform.position;
            gameState.SpawnerState.SpawnedObjects.Add(new SavedGameState.SimpleSpawnerState.Entry()
            {
                Location = new System.Tuple<float, float, float>(location.x, location.y, location.z)
                
            });
        }
    }

    void Start()
    {
        for(int i = 0; i < NumObjects; i++)
        {
            // need to make the Instantiation a variable so that its transform gets saved and im not just putting in default prefab values (MAJOR DEBUGGING TIME WENT HERE)
            var oliver = Instantiate(olive, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity); // instantiate an olive at a random position in the test scene
            SpawnedOlives.Add(new System.Tuple<GameObject>(oliver));
        }

        Saving.Instance.RegisterHandler(this);

    }

    void OnDestroy()
    {
        Saving.Instance.DeRegisterHandler(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

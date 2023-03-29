using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOliveSpawner : MonoBehaviour, saveable
{
    [SerializeField] string ID = "OliverSpawner-1";
    [SerializeField] int NumObjects = 5;
    public GameObject olive;
    List<GameObject> SpawnedOlives = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < NumObjects; i++)
        {
            Instantiate(olive, new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)), Quaternion.identity); // instantiate an olive at a random position in the test scene
            SpawnedOlives.Add(olive);
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

    public void PrepareForSave(SavedGameState gameState)
    {
        // throw new System.NotImplementedException(); default, generated statement i commented out
        gameState.SpawnerState.ID = ID;
        foreach(var spawned in SpawnedOlives)
        {
            gameState.SpawnerState.SpawnedObjects.Add(new SavedGameState.SimpleSpawnerState.Entry()
            {
                Location = spawned.transform.position,
                Type = spawned
            }) ;
        }
    }
}

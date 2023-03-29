using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOliveSpawner : MonoBehaviour, saveable
{
    [SerializeField] string ID = "OliverSpawner-1";
    [SerializeField] int NumObjects = 5;
    public GameObject olive;
    List<System.Tuple<GameObject>> SpawnedOlives = new List<System.Tuple<GameObject>>();
    // List<GameObject> SpawnedOlives = new List<GameObject>();

    // Start is called before the first frame update

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

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnList : MonoBehaviour {

    // A list of all the subscribed spawnpoints
    public List<SpawnLocation> locations;

    // A reference to this singleton
    public static SpawnList Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Subscribe(SpawnLocation location)
    {
        locations.Add(location);
    }

    public void GetSpawnPoint(Team team)
    {
        int randomStart = Random.Range(0, locations.Count - 1);

        print("locations.Count: " + locations.Count);
        print("trying to grab spawnpoint from incomplete method GetSpawnPoint");
    }
}

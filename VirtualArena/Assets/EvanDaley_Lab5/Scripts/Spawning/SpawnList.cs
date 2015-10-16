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

    /// <summary>
    /// A SpawnLocation is trying to join the list of SpawnLocations. 
    /// </summary>
    /// <param name="location"></param>
    public void Subscribe(SpawnLocation location)
    {
        locations.Add(location);
    }

    public SpawnLocation GetSpawnLocation(Team team)
    {
        print(locations.Count);
        if (locations.Count == 0)
            return null;

        // Choose a random index to start at in the list
        int randomStart = Random.Range(0, locations.Count - 1);

        for (int i = randomStart; i < locations.Count; i++)
        {
            // Check if the spawnpoint is clear and empty
            if (locations[i].isClear() && locations[i].team == team)
                return locations[i];
        }

        // Repeat for index 0 thru randomStart
        for (int i = 0; i < randomStart; i++)
        {
            // Check if the spawnpoint is clear and empty
            if (locations[i].isClear() && locations[i].team == team)
                return locations[i];
        }

        return null;
    }
}

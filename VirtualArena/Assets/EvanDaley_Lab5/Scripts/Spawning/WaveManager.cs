using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

    public bool debug = true;

    public Queue spawnList;
    public GameObject cyborgPrefab;

    private int wave = 0;


	void Start () {
        // Create the spawnList
        spawnList = new Queue();

        // Check if there are any enemies in the queue waiting to spawn
        InvokeRepeating("CheckSpawnQueue", 3F, 1F);

        // Check if the enemy count is 0 every 6 seconds. Wide intervals makes sure we dont send two waves at once.
        InvokeRepeating("CheckEnemyCount", .1F, 3F);
	}

    public void CheckEnemyCount()
    {
        if(ActorList.Instance.ActorCount == 0)
        {
            AddWaveToQueue();
        }

        if(debug == true)
        {
            print("Checking enemy count: " + ActorList.Instance.ActorCount);
        }
    }

    void CheckSpawnQueue()
    {
        if (spawnList.Count == 0)
        {
            if (debug == true)
                print("Spawn queue empty");

            return;
        }            

        SpawnLocation location = SpawnList.Instance.GetSpawnLocation(Team.red);

        if (location != null)
        {
            GameObject cyborg = GameObject.Instantiate(spawnList.Dequeue() as GameObject, location.transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            if(debug)
                print("No spawn locations found");
        }
    }

    void AddWaveToQueue()
    {
        if (debug)
            print("Adding wave");

        wave++;

        for(int i = 0; i < wave; i++)
        {
            spawnList.Enqueue(cyborgPrefab);
        }
    }

    public int Wave
    {
        get { return wave; }
    }
}

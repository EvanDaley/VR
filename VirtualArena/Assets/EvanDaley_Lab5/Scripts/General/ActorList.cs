using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorList : MonoBehaviour
{

    // A list of all the subscribed spawnpoints
    public List<GameObject> actors;

    // A reference to this singleton
    public static ActorList Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Subscribe(GameObject actor)
    {
        actors.Add(actor);
    }

    public GameObject GetClosestEnemyActor(Team team)
    {
        //int randomStart = Random.Range(0, locations.Count - 1);

        // walk through all actors
        // check if different team
        // check distance
        // return closest target

        return null;
    }
}

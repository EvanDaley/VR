using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorList : MonoBehaviour
{

    // A list of all the subscribed spawnpoints
    private List<GameObject> actors;

    // A reference to this singleton
    public static ActorList Instance;

    void Awake()
    {
        actors = new List<GameObject>();
        Instance = this;
    }

    public void Subscribe(GameObject actor)
    {
        actors.Add(actor);
    }

    public void UnSubscribe(GameObject actor)
    {
        if (actors.Contains(actor))
            actors.Remove(actor);
    }

    public int ActorCount
    {
        get
        {
            return actors.Count;
        }
    }

    public GameObject GetClosestEnemyActor(Team team, Vector3 position)
    {
        if (actors.Count == 0)
            return null;

        int randomStart = Random.Range(0, actors.Count - 1);

        // check if different team
        // check distance
        // return closest target

        float distance = float.MaxValue;
        GameObject closestObject = null;

        for(int i = randomStart; i < actors.Count-1; i++)
        {

            // check team

            //if appropriate team
                distance = 5; // Vector3.Distance(actor[i].transform.position,  
        }

        // REPEAT for first entries

        for(int i = 0; i < randomStart; i++)
        {
            // check team

            // check for smallest distance
        }

        if(distance < float.MaxValue)
        {
            return closestObject;
        }

        print("Get closest actor remains unfinished");
        print(distance);
        return null;
    }
}

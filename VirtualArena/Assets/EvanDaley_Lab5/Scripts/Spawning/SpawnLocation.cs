using UnityEngine;
using System.Collections;

public class SpawnLocation : MonoBehaviour {

    public Team team;
    public float emptyTimer;

    void Start()
    {
        TrySubscribe();
    }

    void TrySubscribe()
    {
        if (SpawnList.Instance != null)
            SpawnList.Instance.Subscribe(this);
        else
        {
            print("SpawnPoint Failed to Subscribe to SpawnList");
            Invoke("TrySubscribe", .1F);
        }
    }

    public bool isClear()
    {
        // If nothing has touched this object for .5 seconds
        if(emptyTimer < Time.time)
            return true;

        return false;
    }

    void OnTriggerStay()
    {
        emptyTimer = Time.time + .5f;
    }

    public bool hasTeam(Team team)
    {
        return team == this.team;
    }
}

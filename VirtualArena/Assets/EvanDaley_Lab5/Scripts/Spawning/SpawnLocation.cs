using UnityEngine;
using System.Collections;

public class SpawnLocation : MonoBehaviour {

    public Team team;

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

    public bool hasTeam(Team team)
    {
        return team == this.team;
    }
}

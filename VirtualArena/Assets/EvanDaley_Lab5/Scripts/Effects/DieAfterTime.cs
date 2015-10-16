using UnityEngine;
using System.Collections;

public class DieAfterTime : MonoBehaviour {

    // The prefab to instantiate on death (could be a ragdoll)
    public GameObject explosion;

    // The time that this object will die (measure in seconds since game start)
    float deathTime = float.MaxValue;

    // The life span of this object
    public float lifeTime = 3f;

    // The points the player will get for destroying this object
    public int destructionScore = 0;

	void Start () {
        // Set the marker. When game-time passes this marker the object will be destroyed.
        deathTime = Time.time + lifeTime;
	}
	
	void Update () {
        // Use a timer instead of invoke so we don't get ghost objects
        if (Time.time > deathTime)
            Die();
	}

    void Die()
    {
        ScoreManager.Instance.AddScore(destructionScore);

        if (explosion != null)
            GameObject.Instantiate(explosion, transform.position, transform.rotation);

        ActorList.Instance.UnSubscribe(gameObject);
        Destroy(gameObject);
    }
}

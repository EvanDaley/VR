using UnityEngine;
using System.Collections;

public class DieAfterTime : MonoBehaviour {

    float deathTime = 1000f;
    public float lifeTime = 3f;

	// Use this for initialization
	void Start () {
        deathTime = Time.time + lifeTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > deathTime)
            Destroy(this.gameObject);
	}
}

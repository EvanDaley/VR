using UnityEngine;
using System.Collections;

public class TimeManager : MonoBehaviour {

    public float timeScale = .5F;

	// Use this for initialization
	void Start () {
        Time.timeScale = timeScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

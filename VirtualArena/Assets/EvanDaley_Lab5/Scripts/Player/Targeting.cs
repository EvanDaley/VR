using UnityEngine;
using System.Collections;

public class Targeting : MonoBehaviour {

    // The current target we are looking at
    private Transform targetTransform;
    private Ray ray;
    private RaycastHit hit;

	void Start ()
    {

	}
	
	void Update () {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 1000);

        if(Physics.Raycast(ray, out hit, 100F))
        {
            targetTransform = hit.transform;
        }
	}

    /// <summary>
    /// Returns the current transform that the player is looking at.
    /// </summary>
    public Transform Target
    {
        get
        {
            if (targetTransform != null)
                return targetTransform;
            else
                return null;
        }
    }
}

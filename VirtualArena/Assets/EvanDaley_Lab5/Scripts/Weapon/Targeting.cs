using UnityEngine;
using System.Collections;

public class Targeting : MonoBehaviour {

    // The current target we are looking at
    private Transform targetTransform;
    private Vector3 targetPoint;

    // The ray that fires forward from the camera
    private Ray ray;

    // The raycast hit
    private RaycastHit hit;

    // The distance the last hit object was from the camera
    [HideInInspector]
    public float recentDistance = 15f;
    
	void Update () {
        ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward * 1000);

        if(Physics.Raycast(ray, out hit, 100F))
        {
            targetPoint = hit.point;
            Target = hit.transform;
            //print(targetPoint);
        }
        else
        {
            targetTransform = null;
            targetPoint = Camera.main.transform.forward * recentDistance;
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

        set
        {
            // Only check distance when we are hitting a new target
            if(value != targetTransform && value != null)
            {
                recentDistance = Vector3.Distance(RayHitPoint, Camera.main.transform.position);
            }

            targetTransform = value;
        }
    }

    /// <summary>
    /// Returns the current transform that the player is looking at.
    /// </summary>
    public Vector3 RayHitPoint
    {
        get { return targetPoint; }
    }
}

using UnityEngine;
using System.Collections;

public class Targeting : MonoBehaviour, ITargeting {

	private PhotonView m_PhotonView;
	private Vector3 targetPoint;
	private Transform target;

	public Vector3 TargetPoint
	{
		get{ return targetPoint; }
	}

	public Transform Target
	{
		get{ return target; }
	}

	void Start () {
		m_PhotonView = GetComponent<PhotonView> ();
	}
	
	void FixedUpdate()
	{
		if(!m_PhotonView.isMine)
			return;
		
		UpdateTargeting();
	}

	public void UpdateTargeting()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if (Physics.Raycast (camRay, out floorHit, 100)) {
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			// Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			//playerToMouse.y = 0f;
			
			targetPoint = floorHit.point;
			target = floorHit.transform;
		} else {
			//targetPoint = (gameObject.transform.forward * 10) + gameObject.transform.position;
		}
	}
}

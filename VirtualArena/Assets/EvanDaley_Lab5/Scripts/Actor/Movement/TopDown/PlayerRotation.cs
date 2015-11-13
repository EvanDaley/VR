using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour {

	Vector3 target;
	PhotonView m_PhotonView;

	void Awake()
	{
		m_PhotonView = GetComponentInParent<PhotonView>();
	}

	void FixedUpdate()
	{
		if(!m_PhotonView.isMine)
			return;

		Targeting();
		Turning();
	}

	void Targeting()
	{
		// Create a ray from the mouse cursor on screen in the direction of the camera.
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// Create a RaycastHit variable to store information about what was hit by the ray.
		RaycastHit floorHit;
		
		// Perform the raycast and if it hits something on the floor layer...
		if(Physics.Raycast (camRay, out floorHit, 100))
		{
			// Create a vector from the player to the point on the floor the raycast from the mouse hit.
			Vector3 playerToMouse = floorHit.point - transform.position;
			
			// Ensure the vector is entirely along the floor plane.
			//playerToMouse.y = 0f;
			
			target = playerToMouse;
		}
	}

	void Turning()
	{
		// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
		Quaternion newRotatation = Quaternion.LookRotation (target);
		
		// Set the player's rotation to this new rotation.
		transform.rotation = newRotatation;
	}
}

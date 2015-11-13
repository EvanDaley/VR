using UnityEngine;
using System.Collections;

public class SimpleAIRotation : MonoBehaviour {

	private AITargeting m_AITargeting;
	private PhotonView m_PhotonView;

	// Use this for initialization
	void Awake () {
		m_AITargeting = GetComponentInParent<AITargeting>();

		print ("Update m_PhotonView");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Turning();
	}

	void Turning()
	{
		if(m_AITargeting.target == null)
			return;

		// Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
		Vector3 relativePos = m_AITargeting.target.position - transform.position;

		Quaternion newRotatation = Quaternion.LookRotation (relativePos);
		
		// Set the player's rotation to this new rotation.
		transform.rotation = newRotatation;
	}
}

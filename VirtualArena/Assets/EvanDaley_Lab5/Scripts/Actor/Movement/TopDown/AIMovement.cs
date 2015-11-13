using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

	public float stoppingDistance = 2f;
	private AITargeting m_AITargeting;
	public float moveSpeed = 5f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;

	PhotonView m_PhotonView;

	void Awake()
	{
		m_PhotonView = GetComponent<PhotonView>();
		anim = GetComponent<Animator>();
		playerRigidBody = GetComponent<Rigidbody>();
		m_AITargeting = GetComponent<AITargeting>();
	}

	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Do we control this object?
		if(m_PhotonView.isMine || (m_PhotonView.isSceneView && PhotonNetwork.isMasterClient) || PhotonNetwork.offlineMode || !PhotonNetwork.connected)
			Move ();
	}

	void Move()
	{
		if(m_AITargeting.target == null)
			return;
			
		float distance = Vector3.Distance (transform.position,m_AITargeting.target.position);
		if(distance<stoppingDistance)
			return;

		// Set the movement vector based on the axis input
		movement = Vector3.MoveTowards (transform.position,m_AITargeting.target.position,moveSpeed * Time.deltaTime);
		
		// Move the player to its current position plus movement
		playerRigidBody.MovePosition (movement);
	}
}

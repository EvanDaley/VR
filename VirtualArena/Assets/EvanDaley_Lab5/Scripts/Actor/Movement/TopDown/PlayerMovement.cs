using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 6F;		// the speed the player will move at

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidBody;

	PhotonView m_PhotonView;


	void Awake()
	{
		m_PhotonView = GetComponent<PhotonView>();
		anim = GetComponent<Animator>();
		playerRigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if(!m_PhotonView.isMine)
			return;

		float h = CrossPlatformInputManager.GetAxisRaw ("Horizontal");
		float v = CrossPlatformInputManager.GetAxisRaw("Vertical");

		Move(h, v);

		Animating(h, v);
	}

	void Update()
	{
		if(!m_PhotonView.isMine)
			return;

		if(Input.GetButtonDown ("Jump"))
		{
			Ray ray = new Ray(transform.position, Vector3.down);
			if(Physics.Raycast(ray,1f))
			{
				playerRigidBody.AddForce (Vector3.up*350);
			}
		}
	}

	void Move(float h, float v)
	{
		// Set the movement vector based on the axis input
		movement.Set(h, 0f, v);

		// Normalize the vector to get direction
		movement = movement.normalized * moveSpeed * Time.deltaTime;

		// Move the player to its current position plus movement
		playerRigidBody.MovePosition (transform.position + movement);
	}

	void Animating(float h, float v)
	{

	}

}

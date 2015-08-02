using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject spaceCursorPrefab;
	public GameObject spaceCursor;
	public Transform spaceCursorTransform;

	public Vector3 moveTarget;

	public GameObject selected;

	private Transform _transform;
	private CardboardHead _cardHead;
	private NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
		_transform = GetComponent<Transform>();
		_cardHead = GetComponentInChildren<CardboardHead>();
		_navMeshAgent = GetComponent<NavMeshAgent>();
		_navMeshAgent.updateRotation = false;

		if(spaceCursor == null)
		{
			spaceCursor = GameObject.Instantiate(spaceCursorPrefab, transform.position + (Vector3.forward * 5), transform.rotation) as GameObject;
			spaceCursor.transform.SetParent (Camera.main.transform);
			spaceCursorTransform = spaceCursor.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Debug.Log ("Button was pressed");

			// switch(decide what to do based on selection and gaze target)

			//selected = GameObject.CreatePrimitive (PrimitiveType.Cube) as GameObject;
			//selected.transform.position = spaceCursorTransform.position;
			// create object and give it the "holo" script so it can float, rotate, and slide without crashing into things
		
			Ray ray = _cardHead.Gaze;
			RaycastHit hit;
			if(Physics.Raycast (ray,out hit,50))
			{
				if(hit.collider.tag == "Ground")
				{
					moveTarget = hit.point;
					_navMeshAgent.SetDestination (moveTarget);
				}
			}

		}
	}
}

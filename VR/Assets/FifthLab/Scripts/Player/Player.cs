using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public GameObject spaceCursorPrefab;
	public GameObject spaceCursor;
	public Transform spaceCursorTransform;
	public float rayDistance = 13f;

	public Vector3 moveTarget;

	private GameObject selected;

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

			// create object and give it the "holo" script so it can float, rotate, and slide without crashing into things
		
			Ray ray = _cardHead.Gaze;
			RaycastHit hit;
			if(Physics.Raycast (ray,out hit,rayDistance))
			{
				if(hit.collider.tag == "Ground")
				{
					case_Ground (hit.point);
				}
				else if(hit.collider.tag == "Object")
				{
					case_Object(hit.collider.gameObject);
				}

			}
			else
			{
				// we hit nothing, we could move to that spot or bring up a menu
				AutoMoveForward ();

				//selected = GameObject.CreatePrimitive (PrimitiveType.Cube) as GameObject;
				//selected.transform.position = spaceCursorTransform.position;
			}

		}
	}

	void case_Ground(Vector3 hitPoint)
	{
		SetNavmeshTarget (hitPoint);
	}

	void case_Object(GameObject hitObject)
	{

	}

	void AutoMoveForward()
	{
		Vector3 highPoint = _cardHead.transform.position + (_cardHead.transform.forward * 20);

		Ray ray = new Ray(highPoint, Vector3.down);
		Vector3 target = PhysicsTools.GetRayHitpoint (ray);

		if(target != Vector3.zero)
			SetNavmeshTarget (target);
	}

	void SetNavmeshTarget(Vector3 target)
	{
		moveTarget = target;
		_navMeshAgent.SetDestination (target);
	}

	
}

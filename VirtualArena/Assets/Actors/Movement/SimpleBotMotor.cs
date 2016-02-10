using UnityEngine;
using System.Collections;

public class SimpleBotMotor : MonoBehaviour, IMove {

	[Tooltip("Yes means the Nav Agent will automatically rotate the character")]
	public bool updateRotation;

	[Tooltip("The speed at which the character walks.")]
	public float walkSpeed = 5F;

	private Vector3 target = Vector3.zero;
	
	public Vector3 Target 
	{ 
		get { return target; }
		set 
		{ 
			target = value; 

			if(navAgent == null)
				navAgent = GetComponent<NavMeshAgent> ();
			
			navAgent.SetDestination (target);

			navAgent.Resume ();

			print ("Has path? " + navAgent.hasPath);
		}
	}

	private NavMeshAgent navAgent;

	void Start()
	{
		navAgent = GetComponent<NavMeshAgent> ();
		navAgent.updateRotation = updateRotation;
	}

	void Update()
	{
		Vector3 movePoint = navAgent.nextPosition;
		movePoint = Vector3.MoveTowards (transform.position, movePoint, walkSpeed * Time.deltaTime);

		print ("Path? " + navAgent.hasPath);
	}
}

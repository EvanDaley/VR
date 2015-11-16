using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PhotonView))]
public class InstanceTracker : Singleton<InstanceTracker> {
	
	public List<Team> trackableObjects;
	private PhotonView m_PhotonView;

	void Awake()
	{
		m_PhotonView = GetComponent<PhotonView>();
		trackableObjects = new List<Team>();
	}

	/// <summary>
	/// As objects are created they subscribe themselves to the list which will be maintained
	/// by the master client.
	/// </summary>
	/// <param name="team">Team.</param>
	public void Subscribe(Team team)
	{
		trackableObjects.Add (team);
	}

	/// <summary>
	/// As objects are created they subscribe themselves to the list which will be maintained
	/// by the master client.
	/// </summary>
	/// <param name="team">Team.</param>
	public void Unsubscribe(Team team)
	{
		if(trackableObjects.Contains (team))
			trackableObjects.Remove (team);
	}

	/// <summary>
	/// Find the closest targetable object that is NOT on myTeam
	/// </summary>
	/// <param name="myTeam">My team.</param>
	public Team GetClosestTarget(Team me)
	{
		Team closestTarget = null;
		float minDistance = float.MaxValue;
		float curDistance = 0;

		foreach(Team curTarget in trackableObjects)
		{
			if(curTarget != null)
			{
				if(curTarget.ID != me.ID)
				{
					curDistance = Vector3.Distance (me.transform.position, curTarget.transform.position);

					// Possibly more processor friendly:
					//Vector3 difference = me.transform.position - curTarget.transform.position;
					//curDistance = Vector3.SqrMagnitude(difference)

					if(curDistance < minDistance)
					{
						minDistance = curDistance;
						closestTarget = curTarget;
					}
				}
			}
		}

		return closestTarget;
	}

	 /*
	 * Due to the difficult nature of referencing objects between clients we have 
	 * chosen to avoid this entirely. Instead AI will find and target players 
	 * using the master list only. The list will not be updated across clients.
	 */		                  
	[PunRPC]
	public void AddObject(Team team)
	{

	}
}

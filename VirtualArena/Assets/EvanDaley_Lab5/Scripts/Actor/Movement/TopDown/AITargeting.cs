using UnityEngine;
using System.Collections;

public class AITargeting : MonoBehaviour {

	public Transform target;
	private Team m_Team;
	public float updateInterval = 1f;
	private float cooldown = 0;

	PhotonView m_PhotonView;

	void Awake()
	{
		m_PhotonView = GetComponent<PhotonView>();
		m_Team = GetComponent<Team>();
	}

	void Update()
	{
		cooldown -= Time.deltaTime;

		if(cooldown < 0)
		{
			// Only repeat if we are still the master 
			if(m_PhotonView.isMine || (m_PhotonView.isSceneView && PhotonNetwork.isMasterClient) || PhotonNetwork.offlineMode || !PhotonNetwork.connected)
				UpdateTargeting ();

			cooldown = updateInterval;
		}
	}

	void UpdateTargeting()
	{
		Team temp;
		temp = InstanceTracker.Instance.GetClosestTarget (m_Team);

		if(temp != null)
			target = temp.transform;
	
	}
}
